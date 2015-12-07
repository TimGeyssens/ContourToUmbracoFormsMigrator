using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Umbraco.Core;
using umbraco.DataLayer;
using Umbraco.Forms.Core.Enums;
using Umbraco.Forms.Migration.Data.Storage;


namespace Umbraco.Forms.Migration
{
    public class MigrationService
    {
        public MigrationService()
        {
            
        }
        public void Migrate(string connString)
        {
            var sql = DataLayerHelper.CreateSqlHelper(connString);
            
            using (var fs = new FormStorage(sql))
            {
                foreach (var form in fs.GetAllForms(false))
                {
                    var v4Form = new Umbraco.Forms.Core.Form();

                    v4Form.Name = form.Name;
                    v4Form.DisableDefaultStylesheet = form.DisableDefaultStylesheet;
                    v4Form.FieldIndicationType = (FormFieldIndication)System.Enum.Parse(typeof(FormFieldIndication), ((int)form.FieldIndicationType).ToString()); ;
                    v4Form.GoToPageOnSubmit = form.GoToPageOnSubmit;
                    v4Form.HideFieldValidation = form.HideFieldValidation;
                    v4Form.Indicator = form.Indicator;
                    v4Form.InvalidErrorMessage = form.InvalidErrorMessage;
                    v4Form.ManualApproval = form.ManualApproval;
                    v4Form.MessageOnSubmit = form.MessageOnSubmit;
                    v4Form.RequiredErrorMessage = form.RequiredErrorMessage;
                    v4Form.ShowValidationSummary = form.ShowValidationSummary;
                    v4Form.StoreRecordsLocally = form.StoreRecordsLocally;
                    v4Form.XPathOnSubmit = form.XPathOnSubmit;

                    v4Form.NextLabel = "Next";
                    v4Form.PrevLabel = "Previous";
                    v4Form.SubmitLabel = "Submit";

                    foreach(var page in form.Pages)
                    {
                        var v4Page = new Umbraco.Forms.Core.Page();

                        v4Page.Caption = page.Caption;
                       
                       
                        foreach(var fieldset in page.FieldSets)
                        {
                            var v4Fieldset = new Umbraco.Forms.Core.FieldSet();
                            v4Fieldset.Caption = fieldset.Caption;

                            var v4Container = new Umbraco.Forms.Core.FieldsetContainer();
                            v4Container.Width = 12;

                            foreach (var field in fieldset.Fields)
                            {
                                var v4Field = new Umbraco.Forms.Core.Field();
                                v4Field.Id = field.Id;
                                v4Field.Caption = field.Caption;
                                v4Field.ToolTip = field.ToolTip;
                                v4Field.FieldTypeId = field.FieldTypeId;
                                v4Field.InvalidErrorMessage = field.InvalidErrorMessage;
                                v4Field.Mandatory = field.Mandatory;
                                v4Field.RequiredErrorMessage = field.RequiredErrorMessage;
                                v4Field.RegEx = field.RegEx;

                                using (var pvs = new PreValueStorage(sql))
                                {
                                    var prevalues = new List<string>();
                                    foreach (var prevalue in pvs.GetAllPreValues(field).OrderBy(x => x.SortOrder))
                                    {
                                        prevalues.Add(prevalue.Value);
                                    }
                                    v4Field.PreValues = prevalues;
                                }

                                v4Field.Condition = new Core.FieldCondition();
                                v4Field.Condition.Enabled = field.Condition.Enabled;
                                v4Field.Condition.ActionType = (Core.FieldConditionActionType)System.Enum.Parse(typeof(Core.FieldConditionActionType), ((int)field.Condition.ActionType).ToString()); ;
                                v4Field.Condition.LogicType = (Core.FieldConditionLogicType)System.Enum.Parse(typeof(Core.FieldConditionLogicType), ((int)field.Condition.LogicType).ToString()); ;

                                var rules = new List<Core.FieldConditionRule>();
                                foreach (var rule in field.Condition.Rules)
                                {
                                    var v4Rule = new Core.FieldConditionRule();

                                    v4Rule.Field = rule.Field;
                                    v4Rule.Operator = (Core.FieldConditionRuleOperator)System.Enum.Parse(typeof(Core.FieldConditionRuleOperator), ((int)rule.Operator).ToString()); ;
                                    v4Rule.Value = rule.Value;

                                    rules.Add(v4Rule);
                                }
                                v4Field.Condition.Rules = rules;

                                using (var ss = new SettingsStorage(sql))
                                {
                                    foreach (var setting in  ss.GetSettingsAsList(field.Id))
                                    {
                                        v4Field.Settings.Add(setting.Key,setting.Value);
                                    }
                                }
                                v4Container.Fields.Add(v4Field);
                            }

                            v4Fieldset.Containers.Add(v4Container);

                            v4Page.FieldSets.Add(v4Fieldset);
                        }

                        v4Form.Pages.Add(v4Page);
                    }

                    using (var ws = new WorkflowStorage(sql))
                    {
                        var wfs = ws.GetAllWorkFlows(form);

                        foreach (var workflow in wfs)
                        {
                            using (var wsv4 = new Forms.Data.Storage.WorkflowStorage())
                            {
                                
                                var v4Workflow = new Core.Workflow();
                                v4Workflow.Name = workflow.Name;
                                v4Workflow.Id = workflow.Id;
                                v4Workflow.Type = workflow.Type;
                                v4Workflow.ExecutesOn = (Core.Enums.FormState)System.Enum.Parse(typeof(Core.Enums.FormState), ((int)workflow.ExecutesOn).ToString()); ; ;
                                v4Workflow.Settings = workflow.Settings;
                                wsv4.InsertWorkflow(v4Form,v4Workflow);
                            }
                        }
                    }


                    using (var s = new Forms.Data.Storage.FormStorage()) { 
                    s.InsertForm(v4Form);
                    }
                }
            }


        }

        
    }
}
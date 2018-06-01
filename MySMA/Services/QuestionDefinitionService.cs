using System;
using System.Collections.Generic;
using System.Linq;
using MySMA.Models;
using MySMA.Properties;

namespace MySMA.Services
{
    public class QuestionDefinitionService : IQuestionDefinitionService
    {
        private Dictionary<QuestionDefinitionId, QuestionDefinitionBase> _definitions;

        public QuestionDefinitionService()
        {
            InitializeDictionary();

            FirstDefinitionId = QuestionDefinitionId.BorrowerDateOfBirth;
        }

        public QuestionDefinitionId FirstDefinitionId { get; private set; }

        public QuestionDefinitionBase GetFirstDefinition()
        {
            return _definitions[FirstDefinitionId];
        }

        public QuestionDefinitionBase GetDefinition(QuestionDefinitionId id)
        {
            return _definitions[id];
        }

        #region private

        private void InitializeDictionary()
        {
            _definitions = new Dictionary<QuestionDefinitionId, QuestionDefinitionBase>
            {
                {
                    QuestionDefinitionId.CurrentLienHolder,
                    new StringQuestionDefinition
                    {
                        Id = QuestionDefinitionId.CurrentLienHolder,
                        PromptText = Resources.QuestionDefinition_PromptText_CurrentLienHolder,
                        DefaultNextQuestionId = QuestionDefinitionId.RecentlySoldProperties
                    }
                },
                {
                    QuestionDefinitionId.BorrowerDateOfBirth,
                    new DateQuestionDefinition
                    {
                        Id = QuestionDefinitionId.BorrowerDateOfBirth,
                        PromptText = Resources.QuestionDefinition_PromptText_BorrowerDateOfBirth,
                        DefaultNextQuestionId = QuestionDefinitionId.YearsOfSchool
                    }
                },
                {
                    QuestionDefinitionId.YearsOfSchool,
                    new DropDownQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.YearsOfSchool,
                        PromptText = Resources.QuestionDefinition_PromptText_YearsOfSchool,
                        DefaultNextQuestionId = QuestionDefinitionId.GraduatedFromCollege,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_BlankOption, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_LessThan12, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_13, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_14, AnswerId = 3},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_15, AnswerId = 4},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_16, AnswerId = 5},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_17, AnswerId = 6},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_18, AnswerId = 7},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_19, AnswerId = 8},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_20, AnswerId = 9},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_GreaterThan20, AnswerId = 10}
                        }
                    }
                },
                {
                    QuestionDefinitionId.GraduatedFromCollege,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.GraduatedFromCollege,
                        PromptText = Resources.QuestionDefinition_PromptText_GraduateFromCollege,
                        DefaultNextQuestionId = QuestionDefinitionId.MaritalStatus,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.MaritalStatus,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.MaritalStatus,
                        PromptText = Resources.QuestionDefinition_PromptText_MaritalStatus,
                        DefaultNextQuestionId = QuestionDefinitionId.DependencyExistance,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer {PromptText = Resources.AnswerDefinition_PromptText_Married, AnswerId = 0},
                            new PossibleAnswer {PromptText = Resources.AnswerDefinition_PromptText_UnMarried, AnswerId = 1},
                            new PossibleAnswer {PromptText = Resources.AnswerDefinition_PromptText_Separated, AnswerId = 2},
                        }
                    }
                },
                {
                    QuestionDefinitionId.DependencyExistance,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DependencyExistance,
                        PromptText = Resources.QuestionDefinition_PromptText_DependencyExistance,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentAddress,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.NumberOfDependents},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.NumberOfDependents,
                    new DropDownQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.NumberOfDependents,
                        PromptText = Resources.QuestionDefinition_PromptText_NumberOfDependents,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentAddress,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_BlankOption, AnswerId = 0},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_1, AnswerId = 1},                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_2, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_3, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_4, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_5, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_6, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_7, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_8, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_9, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_10, AnswerId = 10}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.OwnOrRent,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OwnOrRent,
                        PromptText = Resources.QuestionDefinition_PromptText_OwnOrRent,
                        DefaultNextQuestionId = QuestionDefinitionId.AmountOfRent,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Own, AnswerId = 0, NextQuestion = QuestionDefinitionId.OwnMonthlyPayment},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Rent, AnswerId = 1}
                        }
                    }
                },
                {                   
                    QuestionDefinitionId.OwnMonthlyPayment,
                    new CurrencyQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OwnMonthlyPayment,
                        PromptText = Resources.QuestionDefinition_PromptText_OwnMonthlyPayment,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentHomePlan
                    }
                },
                {
                    QuestionDefinitionId.CurrentHomePlan,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.CurrentHomePlan,
                        PromptText = Resources.QuestionDefinition_PromptText_CurrentHomePlan,
                        DefaultNextQuestionId = QuestionDefinitionId.WhenBuyHome,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_SellingCurrentHomeSameTime, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_HomeUnderAgreement, AnswerId = 1, NextQuestion = QuestionDefinitionId.SoldBeforePurchase},                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_PlanToPutToMarket, AnswerId = 2},                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_RentCurrentAndMoveToNewHome, AnswerId = 3},                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_MoveToNewHomeThenDecideWhatToDoWithOld, AnswerId = 4},                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Unknown, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Other, AnswerId = 6}
                        }
                    }
                },
                {
                    QuestionDefinitionId.SoldBeforePurchase,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.SoldBeforePurchase,
                        PromptText = Resources.QuestionDefinition_PromptText_SoldBeforePurchase,
                        DefaultNextQuestionId = QuestionDefinitionId.ClosingDate,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0, NextQuestion = QuestionDefinitionId.WhenBuyHome}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.TimeframeForPurchase,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.TimeframeForPurchase,
                        PromptText = Resources.QuestionDefinition_PromptText_TimeframeForPurchase,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentRealEstateAgent,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_CurrentlyUnderContract, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_OfferPendingAHouse, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_PlanOnPurchasingAProperty, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_ExploringOptions, AnswerId = 3}                                                
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.CurrentRealEstateAgent,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.CurrentRealEstateAgent,
                        PromptText = Resources.QuestionDefinition_PromptText_CurrentRealEstateAgent,
                        DefaultNextQuestionId = QuestionDefinitionId.RecommendAgent,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.AgentInfo},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.RecommendAgent,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.RecommendAgent,
                        PromptText = Resources.QuestionDefinition_PromptText_RecommendAgent,
                        DefaultNextQuestionId = QuestionDefinitionId.IntentionForTheNewProperty,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.IntentionForTheNewProperty,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.IntentionForTheNewProperty,
                        PromptText = Resources.QuestionDefinition_PromptText_IntentionForTheNewProperty,
                        DefaultNextQuestionId = QuestionDefinitionId.EstimatedPurchasePrice,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_MoveIntoInUponClosing, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_MoveInWithin60Days, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_MoveInAfter60Days, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_UseItAsVacationHome, AnswerId = 3},
                            new PossibleAnswer
                            {
                                PromptText = Resources.PossibleAnswers_PromptText_WillBeAnInvestmentProperty,
                                AnswerId = 4,
                                NextQuestion = QuestionDefinitionId.ExperienceOfInvestmentProperties
                            },
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Other, AnswerId = 5}
                        }
                    }
                },
                {
                    QuestionDefinitionId.ExperienceOfInvestmentProperties,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.ExperienceOfInvestmentProperties,
                        PromptText = Resources.QuestionDefinition_PromptText_ExperienceOfInvestmentProperties,
                        DefaultNextQuestionId = QuestionDefinitionId.EstimatedPurchasePrice,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.EstimatedPurchasePrice,
                    new CurrencyQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.EstimatedPurchasePrice,
                        PromptText = Resources.QuestionDefinition_PromptText_EstimatedPurchasePrice,
                        DefaultNextQuestionId = QuestionDefinitionId.TermsApplyingFor,
                    }
                },
                {                    
                    QuestionDefinitionId.TermsApplyingFor,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.TermsApplyingFor,
                        PromptText = Resources.QuestionDefinition_PromptText_TermsApplyingFor,
                        DefaultNextQuestionId = QuestionDefinitionId.CreditRating,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_10YearFixed, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_15YearFixed, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_20YearFixed, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_25YearFixed, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_30YearFixed, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_AdjustableRateMortgage, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Other, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_DoNotKnow, AnswerId = 7}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.CreditRating,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.CreditRating,
                        PromptText = Resources.QuestionDefinition_PromptText_CreditRating,
                        DefaultNextQuestionId = QuestionDefinitionId.AuthorizeCreditReport,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_BelowAverage, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Average, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Good, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_AboveAverage, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.AuthorizeCreditReport,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.AuthorizeCreditReport,
                        PromptText = Resources.QuestionDefinition_PromptText_AuthorizeCreditReport,
                        DefaultNextQuestionId = QuestionDefinitionId.VeteranLoan,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.AuthorizeCreditReportName},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.AuthorizeCreditReportName,
                    new StringQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.AuthorizeCreditReportName,
                        PromptText = Resources.QuestionDefinition_PromptText_AuthorizeCreditReportName,
                        DefaultNextQuestionId = QuestionDefinitionId.VeteranLoan
                    }
                },
                {                    
                    QuestionDefinitionId.VeteranLoan,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.VeteranLoan,
                        PromptText = Resources.QuestionDefinition_PromptText_VeteranLoan,
                        DefaultNextQuestionId = QuestionDefinitionId.TitleHolding,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.MilitaryBranch},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.MilitaryBranch,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.MilitaryBranch,
                        PromptText = Resources.QuestionDefinition_PromptText_MilitaryBranch,
                        DefaultNextQuestionId = QuestionDefinitionId.MilitaryBenefits,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_MilitaryDuty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_ReservesNationalGuard, AnswerId = 1}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.MilitaryBenefits,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.MilitaryBenefits,
                        PromptText = Resources.QuestionDefinition_PromptText_MilitaryBenefits,
                        DefaultNextQuestionId = QuestionDefinitionId.PreviousUseOfVaEntitlement,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_MilitaryBasePay, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_ReserveIncome, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_HousingQuartersAllowance, AnswerId = 2}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.PreviousUseOfVaEntitlement,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.PreviousUseOfVaEntitlement,
                        PromptText = Resources.QuestionDefinition_PromptText_PreviousUseOfVaEntitlement,
                        DefaultNextQuestionId = QuestionDefinitionId.PercentDisabled,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.PercentDisabled,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.PercentDisabled,
                        PromptText = Resources.QuestionDefinition_PromptText_PercentDisabled,
                        DefaultNextQuestionId = QuestionDefinitionId.ListedAsPermanentlyDisabled,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0, NextQuestion = QuestionDefinitionId.TitleHolding}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.ListedAsPermanentlyDisabled,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.ListedAsPermanentlyDisabled,
                        PromptText = Resources.QuestionDefinition_PromptText_ListedAsPermanentlyDisabled,
                        DefaultNextQuestionId = QuestionDefinitionId.TitleHolding,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.TitleHolding,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.TitleHolding,
                        PromptText = Resources.QuestionDefinition_PromptText_TitleHolding,
                        DefaultNextQuestionId = QuestionDefinitionId.EscrowTaxesInTheLoan,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_SingleWoman, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_SingleMan, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_JointTenants, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Trust, AnswerId = 3},
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.EscrowTaxesInTheLoan,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.EscrowTaxesInTheLoan,
                        PromptText = Resources.QuestionDefinition_PromptText_EscrowTaxesInTheLoan,
                        DefaultNextQuestionId = QuestionDefinitionId.EscrowHazardInsuranceInLoan,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.EscrowHazardInsuranceInLoan,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.EscrowHazardInsuranceInLoan,
                        PromptText = Resources.QuestionDefinition_PromptText_EscrowHazardInsuranceInLoan,
                        DefaultNextQuestionId = QuestionDefinitionId.OverdraftFeesOnBankStatements,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.OverdraftFeesOnBankStatements,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OverdraftFeesOnBankStatements,
                        PromptText = Resources.QuestionDefinition_PromptText_OverdraftFeesOnBankStatements,
                        DefaultNextQuestionId = QuestionDefinitionId.RetirementAccountsOr401Ks,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.RetirementAccountsOr401Ks,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.RetirementAccountsOr401Ks,
                        PromptText = Resources.QuestionDefinition_PromptText_RetirementAccountsOr401Ks,
                        DefaultNextQuestionId = QuestionDefinitionId.OwnPropertiesOrLand,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.OwnPropertiesOrLand,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OwnPropertiesOrLand,
                        PromptText = Resources.QuestionDefinition_PromptText_OwnPropertiesOrLand,
                        DefaultNextQuestionId = QuestionDefinitionId.RecentlySoldProperties,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.TypeOfProperty},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.TypeOfProperty,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.TypeOfProperty,
                        PromptText = Resources.QuestionDefinition_PromptText_TypeOfProperty,
                        DefaultNextQuestionId = QuestionDefinitionId.AddressOfProperty,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_CondoTownhouseCondex, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_SingleFamily, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_2Unit, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_3Unit, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_4Unit, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Lot, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_CommercialProperty, AnswerId = 6}                            
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.RecentlySoldProperties,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.RecentlySoldProperties,
                        PromptText = Resources.QuestionDefinition_PromptText_RecentlySoldProperties,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentHouseholdIncome,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.DateOfSale},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.CurrentHouseholdIncome,
                    new CurrencyQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.CurrentHouseholdIncome,
                        PromptText = Resources.QuestionDefinition_PromptText_CurrentHouseholdIncome,
                        DefaultNextQuestionId = QuestionDefinitionId.DurationInCurrentProfession
                    }
                },
                {                    
                    QuestionDefinitionId.DurationInCurrentProfession,
                    new IntegerQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationInCurrentProfession,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationInCurrentProfession,
                        DefaultNextQuestionId = QuestionDefinitionId.SelfEmployed
                    }
                },
                {                    
                    QuestionDefinitionId.SelfEmployed,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.SelfEmployed,
                        PromptText = Resources.QuestionDefinition_PromptText_SelfEmployed,
                        DefaultNextQuestionId = QuestionDefinitionId.EmploymentGaps,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.DurationOfSelfEmplyement},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.EmploymentGaps,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.EmploymentGaps,
                        PromptText = Resources.QuestionDefinition_PromptText_EmploymentGaps,                        
                        DefaultNextQuestionId = QuestionDefinitionId.ReceiveChildSupport,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.DownpaymentCheckingOrSavingsAccount,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.DownpaymentCheckingOrSavingsAccount,
                        PromptText = Resources.QuestionDefinition_PromptText_DownpaymentCheckingOrSavingsAccount,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentRetirement401KLoanOrWithdrawal,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.DownpaymentRetirement401KLoanOrWithdrawal,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.DownpaymentRetirement401KLoanOrWithdrawal,
                        PromptText = Resources.QuestionDefinition_PromptText_DownpaymentRetirement401KLoanOrWithdrawal,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentSaleOfStockOrBonds,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.RequestedTheFunds},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.RequestedTheFunds,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.RequestedTheFunds,
                        PromptText = Resources.QuestionDefinition_PromptText_RequestedTheFunds,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentSaleOfStockOrBonds,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.DownpaymentSaleOfStockOrBonds,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.DownpaymentSaleOfStockOrBonds,
                        PromptText = Resources.QuestionDefinition_PromptText_DownpaymentSaleOfStockOrBonds,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentGift,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.DownpaymentGift,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.DownpaymentGift,
                        PromptText = Resources.QuestionDefinition_PromptText_DownpaymentGift,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentEquityFromPendingSale,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.AmountOfGift},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.AmountOfGift,
                    new CurrencyQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.AmountOfGift,
                        PromptText = Resources.QuestionDefinition_PromptText_AmountOfGift,
                        DefaultNextQuestionId = QuestionDefinitionId.RelationshipOfDonor
                    }
                },
                {                    
                    QuestionDefinitionId.RelationshipOfDonor,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.RelationshipOfDonor,
                        PromptText = Resources.QuestionDefinition_PromptText_RelationshipOfDonor,
                        DefaultNextQuestionId = QuestionDefinitionId.ReceivedGift,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Parent, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Sibling, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Child, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Relative, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Other, AnswerId = 4}                            
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.ReceivedGift,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.ReceivedGift,
                        PromptText = Resources.QuestionDefinition_PromptText_ReceivedGift,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentEquityFromPendingSale,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.DownpaymentEquityFromPendingSale,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.DownpaymentEquityFromPendingSale,
                        PromptText = Resources.QuestionDefinition_PromptText_DownpaymentEquityFromPendingSale,
                        DefaultNextQuestionId = QuestionDefinitionId.OtherSourcesForDownpayment,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.OtherSourcesForDownpayment,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.OtherSourcesForDownpayment,
                        PromptText = Resources.QuestionDefinition_PromptText_OtherSourcesForDownpayment,
                        DefaultNextQuestionId = QuestionDefinitionId.DownPaymentBorrowed,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.DownPaymentBorrowed,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DownPaymentBorrowed,
                        PromptText = Resources.QuestionDefinition_PromptText_DownPaymentBorrowed,
                        DefaultNextQuestionId = QuestionDefinitionId.ChildSupport,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.ChildSupport,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.ChildSupport,
                        PromptText = Resources.QuestionDefinition_PromptText_ChildSupport,
                        DefaultNextQuestionId = QuestionDefinitionId.AlimonyObligation,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.OneOrMoreParentChildSupport},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.OneOrMoreParentChildSupport,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.OneOrMoreParentChildSupport,
                        PromptText = Resources.QuestionDefinition_PromptText_OneOrMoreParentChildSupport,
                        DefaultNextQuestionId = QuestionDefinitionId.AlimonyObligation,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.NumberOfChildDependents},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.NumberOfChildDependents,
                    new IntegerQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.NumberOfChildDependents,
                        PromptText = Resources.QuestionDefinition_PromptText_NumberOfChildDependents,
                        DefaultNextQuestionId = QuestionDefinitionId.DurationOfChildSupportObligation
                    }
                },
                {                    
                    QuestionDefinitionId.AlimonyObligation,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.AlimonyObligation,
                        PromptText = Resources.QuestionDefinition_PromptText_AlimonyObligation,
                        DefaultNextQuestionId = QuestionDefinitionId.RecentDebt,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.DurationOfAlimonyObligation },
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.RecentDebt,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.RecentDebt,
                        PromptText = Resources.QuestionDefinition_PromptText_RecentDebt,
                        DefaultNextQuestionId = QuestionDefinitionId.FileATaxExtension,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.RecentDebtDetails},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.FileATaxExtension,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.FileATaxExtension,
                        PromptText = Resources.QuestionDefinition_PromptText_FileATaxExtension,
                        DefaultNextQuestionId = QuestionDefinitionId.BackTaxesFromAnyPreviousYears,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.BackTaxesFromAnyPreviousYears,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.BackTaxesFromAnyPreviousYears,
                        PromptText = Resources.QuestionDefinition_PromptText_BackTaxesFromAnyPreviousYears,
                        DefaultNextQuestionId = QuestionDefinitionId.UseOfHomeForBusiness,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.PaymentPlan},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.PaymentPlan,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.PaymentPlan,
                        PromptText = Resources.QuestionDefinition_PromptText_PaymentPlan,
                        DefaultNextQuestionId = QuestionDefinitionId.UseOfHomeForBusiness,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.UseOfHomeForBusiness,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.UseOfHomeForBusiness,
                        PromptText = Resources.QuestionDefinition_PromptText_UseOfHomeForBusiness,
                        DefaultNextQuestionId = QuestionDefinitionId.UnreimbursedEmployeeExpenses,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.UnreimbursedEmployeeExpenses,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.UnreimbursedEmployeeExpenses,
                        PromptText = Resources.QuestionDefinition_PromptText_UnreimbursedEmployeeExpenses,
                        DefaultNextQuestionId = QuestionDefinitionId.OutstandingJudgements,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.OutstandingJudgements,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OutstandingJudgements,
                        PromptText = Resources.QuestionDefinition_PromptText_OutstandingJudgements,
                        DefaultNextQuestionId = QuestionDefinitionId.DeclaredBankrupt,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.DeclaredBankrupt,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DeclaredBankrupt,
                        PromptText = Resources.QuestionDefinition_PromptText_DeclaredBankrupt,
                        DefaultNextQuestionId = QuestionDefinitionId.PropertyForeclosed,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.YearOfBankruptcyDischarge},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.PropertyForeclosed,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.PropertyForeclosed,
                        PromptText = Resources.QuestionDefinition_PromptText_PropertyForeclosed,
                        DefaultNextQuestionId = QuestionDefinitionId.DateOfPropertyForeclosed,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0, NextQuestion = QuestionDefinitionId.ObligatedOnAnyLoan}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.ObligatedOnAnyLoan,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.ObligatedOnAnyLoan,
                        PromptText = Resources.QuestionDefinition_PromptText_ObligatedOnAnyLoan,
                        DefaultNextQuestionId = QuestionDefinitionId.UsCitizen,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.UsCitizen,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.UsCitizen,
                        PromptText = Resources.QuestionDefinition_PromptText_UsCitizen,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentlyPartyToALawsuit,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0, NextQuestion = QuestionDefinitionId.PermanentResident}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.PermanentResident,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.PermanentResident,
                        PromptText = Resources.QuestionDefinition_PromptText_PermanentResident,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentlyPartyToALawsuit,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.WorkVisa},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.WorkVisa,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.WorkVisa,
                        PromptText = Resources.QuestionDefinition_PromptText_WorkVisa,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentlyPartyToALawsuit,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.CurrentlyPartyToALawsuit,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.CurrentlyPartyToALawsuit,
                        PromptText = Resources.QuestionDefinition_PromptText_CurrentlyPartyToALawsuit,
                        DefaultNextQuestionId = QuestionDefinitionId.StatusOfLoanDelinquency,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.StatusOfLoanDelinquency,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.StatusOfLoanDelinquency,
                        PromptText = Resources.QuestionDefinition_PromptText_StatusOfLoanDelinquency,
                        DefaultNextQuestionId = QuestionDefinitionId.CoMakerOrEndorser,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.CoMakerOrEndorser,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.CoMakerOrEndorser,
                        PromptText = Resources.QuestionDefinition_PromptText_CoMakerOrEndorser,
                        DefaultNextQuestionId = QuestionDefinitionId.ShortSale,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.ShortSale,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.ShortSale,
                        PromptText = Resources.QuestionDefinition_PromptText_ShortSale,
                        DefaultNextQuestionId = QuestionDefinitionId.DateOfShortSale,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0, NextQuestion = QuestionDefinitionId.OwnershipInterestInAProperty}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.OwnershipInterestInAProperty,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OwnershipInterestInAProperty,
                        PromptText = Resources.QuestionDefinition_PromptText_OwnershipInterestInAProperty,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.HoldTitle},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.HoldTitle,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.HoldTitle,
                        PromptText = Resources.QuestionDefinition_PromptText_HoldTitle,
                        DefaultNextQuestionId = QuestionDefinitionId.TypeOfOwnershipPropety,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Single, AnswerId = 0},                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Jointly, AnswerId = 1},                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Other, AnswerId = 2}
                        }
                    }
                },
                {                    
                    QuestionDefinitionId.TypeOfOwnershipPropety,
                    new RadioButtonQuestionDefinition
                    {                        
                        Id = QuestionDefinitionId.TypeOfOwnershipPropety,
                        PromptText = Resources.QuestionDefinition_PromptText_TypeOfOwnershipPropety,
                        PossibleAnswers = new List<PossibleAnswer>
                        {                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_PrimaryResidence, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_SecondHome, AnswerId = 1},                            
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_InvestmentProperty, AnswerId = 2}
                        }
                    }
                },
                {
                    QuestionDefinitionId.CurrentAddress,
                    new AddressQuestionDefinition
                    {
                        Id = QuestionDefinitionId.CurrentAddress,
                        PromptText = Resources.QuestionDefinition_PromptText_CurrentAddress,
                        StateList = new List<string>(Resources.PossibleAnswer_PromptText_States.Split('|')),
                        DefaultNextQuestionId = QuestionDefinitionId.OwnOrRent
                    }

                },
                {
                    QuestionDefinitionId.ClosingDate,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.ClosingDate,
                        PromptText = Resources.QuestionDefinition_PromptText_ClosingDate,
                        DefaultNextQuestionId = QuestionDefinitionId.WhenBuyHome,
                        Years = 3,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                                {
                    QuestionDefinitionId.WhenBuyHome,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.WhenBuyHome,
                        PromptText = Resources.QuestionDefinition_PromptText_WhenBuyHome,
                        DefaultNextQuestionId = QuestionDefinitionId.PreviousAddress1,
                        Years = - 101,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.PreviousAddress1,
                    new AddressQuestionDefinition
                    {
                        Id = QuestionDefinitionId.PreviousAddress1,
                        PromptText = Resources.QuestionDefinition_PromptText_PreviousAddress1,
                        StateList = new List<string>(Resources.PossibleAnswer_PromptText_States.Split('|')),
                        DefaultNextQuestionId = QuestionDefinitionId.DurationAtPreviousAddress
                    }
                },
                {
                    QuestionDefinitionId.DurationAtPreviousAddress,
                    new MonthYearDurationQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationAtPreviousAddress,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationAtPreviousAddress,
                        DefaultNextQuestionId = QuestionDefinitionId.TimeframeForPurchase
                    }
                },
                {
                    QuestionDefinitionId.AmountOfRent,
                    new CurrencyQuestionDefinition
                    {
                        Id = QuestionDefinitionId.AmountOfRent,
                        PromptText = Resources.QuestionDefinition_PromptText_AmountOfRent,
                        DefaultNextQuestionId = QuestionDefinitionId.DurationAtCurrentRental
                    }
                },
                {
                    QuestionDefinitionId.DurationAtCurrentRental,
                    new MonthYearDurationQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationAtCurrentRental,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationAtCurrentRental,
                        DefaultNextQuestionId = QuestionDefinitionId.PreviousAddress2
                    }
                },
                {
                    QuestionDefinitionId.PreviousAddress2,
                    new AddressQuestionDefinition
                    {
                        Id = QuestionDefinitionId.PreviousAddress2,
                        PromptText = Resources.QuestionDefinition_PromptText_PreviousAddress2,
                        StateList = new List<string>(Resources.PossibleAnswer_PromptText_States.Split('|')),
                        DefaultNextQuestionId = QuestionDefinitionId.DurationAtPreviousRental
                    }
                },
                {
                    QuestionDefinitionId.DurationAtPreviousRental,
                    new MonthYearDurationQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationAtPreviousRental,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationAtPreviousRental,
                        DefaultNextQuestionId = QuestionDefinitionId.TimeframeForPurchase
                    }
                },
                {
                    QuestionDefinitionId.AgentInfo,
                    new NameEmailPhoneQuestionDefinition
                    {
                        Id = QuestionDefinitionId.AgentInfo,
                        PromptText = Resources.QuestionDefinition_PromptText_AgentInfo,
                        DefaultNextQuestionId = QuestionDefinitionId.RecommendAgent
                    }
                },
                {
                    QuestionDefinitionId.AddressOfProperty,
                    new AddressQuestionDefinition
                    {
                        Id = QuestionDefinitionId.AddressOfProperty,
                        PromptText = Resources.QuestionDefinition_PromptText_AddressOfProperty,
                        StateList = new List<string>(Resources.PossibleAnswer_PromptText_States.Split('|')),
                        DefaultNextQuestionId = QuestionDefinitionId.DateOfPropertyPurchase
                    }
                },
                {
                    QuestionDefinitionId.DateOfPropertyPurchase,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DateOfPropertyPurchase,
                        PromptText = Resources.QuestionDefinition_PromptText_DateOfPropertyPurchase,
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentLienHolder,
                        Years = -101,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.DateOfSale,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DateOfSale,
                        PromptText = Resources.QuestionDefinition_PromptText_DateOfSale,
                        DefaultNextQuestionId = QuestionDefinitionId.AddressOfTheSoldProperty,
                        Years = -4,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }

                    }
                },
                {
                    QuestionDefinitionId.AddressOfTheSoldProperty,
                    new AddressQuestionDefinition
                    {
                        Id = QuestionDefinitionId.AddressOfTheSoldProperty,
                        PromptText = Resources.QuestionDefinition_PromptText_AddressOfTheSoldProperty,
                        StateList = new List<string>(Resources.PossibleAnswer_PromptText_States.Split('|')),
                        DefaultNextQuestionId = QuestionDefinitionId.CurrentHouseholdIncome
                    }
                },
                {
                    QuestionDefinitionId.DurationOfSelfEmplyement,
                    new MonthYearDurationQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationOfSelfEmplyement,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationOfSelfEmployement,
                        DefaultNextQuestionId = QuestionDefinitionId.TypeOfBusiness
                    }
                },
                {
                    QuestionDefinitionId.TypeOfBusiness,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.TypeOfBusiness,
                        PromptText = Resources.QuestionDefinition_PromptText_TypeOfBusiness,
                        DefaultNextQuestionId = QuestionDefinitionId.PercentOfBusinessOwnership,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_IndependentContractor, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_ScheduleC, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_SCorporation, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Corporation, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Partnership, AnswerId = 4, NextQuestion = QuestionDefinitionId.OwnMoreThan25Percent},
                        }
                    }
                },
                {
                    QuestionDefinitionId.OwnMoreThan25Percent,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OwnMoreThan25Percent,
                        PromptText = Resources.QuestionDefinition_PromptText_OwnMoreThan25Percent,
                        DefaultNextQuestionId = QuestionDefinitionId.PercentOfBusinessOwnership,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.PercentOfBusinessOwnership,
                    new IntegerQuestionDefinition
                    {
                        Id = QuestionDefinitionId.PercentOfBusinessOwnership,
                        PromptText = Resources.QuestionDefinition_PromptText_PercentOfBusinessOwnership,
                        DefaultNextQuestionId = QuestionDefinitionId.BusinessTaxExtension
                    }
                },
                {
                    QuestionDefinitionId.BusinessTaxExtension,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.BusinessTaxExtension,
                        PromptText = Resources.QuestionDefinition_PromptText_BusinessTaxExtension,
                        DefaultNextQuestionId = QuestionDefinitionId.OtherBusinessInterests,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.OtherBusinessInterests,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OtherBusinessInterests,
                        PromptText = Resources.QuestionDefinition_PromptText_OtherBusinessInterests,
                        DefaultNextQuestionId = QuestionDefinitionId.EmploymentGaps,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.OtherW2Jobs},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.OtherW2Jobs,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.OtherW2Jobs,
                        PromptText = Resources.QuestionDefinition_PromptText_OtherW2Jobs,
                        DefaultNextQuestionId = QuestionDefinitionId.EmploymentGaps,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.EmployerInfo},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.EmployerInfo,
                    new EmployerQuestionDefinition
                    {
                        Id = QuestionDefinitionId.EmployerInfo,
                        PromptText = Resources.QuestionDefinition_PromptText_EmployerInfo,
                        DefaultNextQuestionId = QuestionDefinitionId.TimeOfWorkingOvertime,
                        Years = -50,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = string.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                QuestionDefinitionId.TimeOfWorkingOvertime,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.TimeOfWorkingOvertime,
                        PromptText = Resources.QuestionDefinition_PromptText_TimeOfWorkingOvertime,
                        DefaultNextQuestionId = QuestionDefinitionId.EmploymentGaps,
                        Years = -51,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.DurationOfChildSupport,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationOfChildSupport,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationOfChildSupport,
                        DefaultNextQuestionId = QuestionDefinitionId.Alimony,
                        Years = 19,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.Alimony,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.Alimony,
                        PromptText = Resources.QuestionDefinition_PromptText_Alimony,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentCheckingOrSavingsAccount,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.DurationOfAlimony},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.DurationOfAlimony,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationOfAlimony,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationOfAlimony,
                        DefaultNextQuestionId = QuestionDefinitionId.DownpaymentCheckingOrSavingsAccount,
                        Years = 19,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.DurationOfChildSupportObligation,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationOfChildSupportObligation,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationOfChildSupportObligation,
                        DefaultNextQuestionId = QuestionDefinitionId.AlimonyObligation,
                        Years = 19,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.DurationOfAlimonyObligation,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DurationOfAlimonyObligation,
                        PromptText = Resources.QuestionDefinition_PromptText_DurationOfAlimonyObligation,
                        DefaultNextQuestionId = QuestionDefinitionId.RecentDebt,
                        Years = 19,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.YearOfBankruptcyDischarge,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.YearOfBankruptcyDischarge,
                        PromptText = Resources.QuestionDefinition_PromptText_YearOfBankruptcyDischarge,
                        DefaultNextQuestionId = QuestionDefinitionId.PropertyForeclosed,
                        Years = -26,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.DateOfPropertyForeclosed,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DateOfPropertyForeclosed,
                        PromptText = Resources.QuestionDefinition_PromptText_DateOfPropertyForeclosed,
                        DefaultNextQuestionId = QuestionDefinitionId.ObligatedOnAnyLoan,
                        Years = -26,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.DateOfShortSale,
                    new MonthYearQuestionDefinition
                    {
                        Id = QuestionDefinitionId.DateOfShortSale,
                        PromptText = Resources.QuestionDefinition_PromptText_DateOfShortSale,
                        DefaultNextQuestionId = QuestionDefinitionId.OwnershipInterestInAProperty,
                        Years = -51,
                        MonthList = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = String.Empty, AnswerId = 0},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_January, AnswerId = 1},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_February, AnswerId = 2},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_March, AnswerId = 3},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_April, AnswerId = 4},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_May, AnswerId = 5},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_June, AnswerId = 6},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_July, AnswerId = 7},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_Augst, AnswerId = 8},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_September, AnswerId = 9},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_October, AnswerId = 10},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_November, AnswerId = 11},
                            new PossibleAnswer { PromptText = Resources.PossibleAnswers_PromptText_December, AnswerId = 12},
                        }
                    }
                },
                {
                    QuestionDefinitionId.ReceiveChildSupport,
                    new RadioButtonQuestionDefinition
                    {
                        Id = QuestionDefinitionId.ReceiveChildSupport,
                        PromptText = Resources.QuestionDefinition_PromptText_ReceiveChildSupport ,
                        DefaultNextQuestionId = QuestionDefinitionId.Alimony,
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_Yes, AnswerId = 1, NextQuestion = QuestionDefinitionId.DurationOfChildSupport},
                            new PossibleAnswer { PromptText = Resources.AnswerDefinition_PromptText_No, AnswerId = 0}
                        }
                    }
                },
                {
                    QuestionDefinitionId.RecentDebtDetails,
                    new DebtDetailsQuestionDefinition
                    {
                        Id = QuestionDefinitionId.RecentDebtDetails,
                        PromptText = Resources.QuestionDefinition_PromptText_RecentDebtDetails ,
                        DefaultNextQuestionId = QuestionDefinitionId.FileATaxExtension,
                    }
                }
            

            };
        }

#endregion

    }
}
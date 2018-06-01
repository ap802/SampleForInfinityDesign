using NUnit.Framework;
using MySMA.Models;
using MySMA.Services;
using NUnit.Core;

namespace MySMA.Tests.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleNullReferenceException

    [TestFixture]
    public class QuestionDefinitionServiceTests
    {
        private QuestionDefinitionService _questionDefinitionService;

        [SetUp]
        public void SetUp()
        {
            _questionDefinitionService = new QuestionDefinitionService();
        }

        [Test]
        public void GetDefinition_CurrentLienHolder_NextQuestionIsRecentlySoldProperties()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CurrentLienHolder);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RecentlySoldProperties, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_BorrowerDateOfBirth_NextQuestionIsYearsOfSchool()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.BorrowerDateOfBirth);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.YearsOfSchool, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_YearsOfSchool_NextQuestionIsGraduatedFromCollege()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.YearsOfSchool);

            // Assert
        }

        [Test]
        public void GetDefinition_ValidId_ReturnsCorrectQuestion()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.BorrowerDateOfBirth);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.BorrowerDateOfBirth, definition.Id);
        }

        [Test]
        public void GetFirstDefinition_Invoked_ReturnsCurrentLienHolder()
        {
            // Arrange

            // Act
            var definition = _questionDefinitionService.GetFirstDefinition();

            // Assert
            Assert.AreEqual(QuestionDefinitionId.BorrowerDateOfBirth, definition.Id);

        }

        [Test]
        public void GetDefinition_GraduatedFromCollege_NextQuestionIsMaritalStatus()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.GraduatedFromCollege);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.MaritalStatus, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_MaritalStatus_NextQuestionIsDependencyExistance()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.MaritalStatus);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DependencyExistance, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DependencyExistance_NextQuestionCurrentAddress()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DependencyExistance);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentAddress, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OwnOrRent_NextQuestionIsAmountOfRent()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnOrRent);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AmountOfRent, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_TimeframeForPurchase_NextQuestionIsCurrentRealEstateAgent()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.TimeframeForPurchase);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentRealEstateAgent, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_CurrentRealEstateAgent_NextQuestionIsRecommendAgent()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CurrentRealEstateAgent);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RecommendAgent, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_RecommendAgent_NextQuestionIsIntentionForTheNewProperty()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RecommendAgent);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.IntentionForTheNewProperty, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_IntentionForTheNewProperty_NextQuestionIsEstimatedPurchasePrice()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.IntentionForTheNewProperty);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EstimatedPurchasePrice, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_EstimatedPurchasePrice_NextQuestionIsTermsApplyingFor()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.EstimatedPurchasePrice);

            // Assert
        }

        [Test]
        public void GetDefinition_TermsApplyingFor_NextQuestionIsCreditRating()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.TermsApplyingFor);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CreditRating, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_CreditRating_NextQuestionIsAuthorizeCreditReport()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CreditRating);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AuthorizeCreditReport, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_AuthorizeCreditReport_NextQuestionIsVeteranLoan()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AuthorizeCreditReport);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.VeteranLoan, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_VeteranLoan_NextQuestionIsTitleHolding()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.VeteranLoan);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TitleHolding, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_TitleHolding_NextQuestionIsEscrowTaxesInTheLoan()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.TitleHolding);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EscrowTaxesInTheLoan, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_EscrowTaxesInTheLoan_NextQuestionIsEscrowHazardInsuranceInLoan()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.EscrowTaxesInTheLoan);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EscrowHazardInsuranceInLoan, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_EscrowHazardInsuranceInLoan_NextQuestionIsOverdraftFeesOnBankStatements()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.EscrowHazardInsuranceInLoan);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OverdraftFeesOnBankStatements, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OverdraftFeesOnBankStatements_NextQuestionIsRetirementAccountsOr401Ks()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OverdraftFeesOnBankStatements);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RetirementAccountsOr401Ks, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_RetirementAccountsOr401Ks_NextQuestionIsOwnPropertiesOrLand()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RetirementAccountsOr401Ks);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OwnPropertiesOrLand, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OwnPropertiesOrLand_NextQuestionIsRecentlySoldProperties()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnPropertiesOrLand);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RecentlySoldProperties, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_RecentlySoldProperties_NextQuestionIsCurrentHouseholdIncome()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RecentlySoldProperties);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentHouseholdIncome, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_CurrentHouseholdIncome_NextQuestionIsDurationInCurrentProfession()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CurrentHouseholdIncome);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DurationInCurrentProfession, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationInCurrentProfession_NextQuestionIsSelfEmployed()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationInCurrentProfession);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.SelfEmployed, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_SelfEmployed_NextQuestionIsEmploymentGaps()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.SelfEmployed);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EmploymentGaps, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_EmploymentGaps_NextQuestionIsReceiveChildSupport()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.EmploymentGaps);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ReceiveChildSupport, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DownpaymentCheckingOrSavingsAccount_NextQuestionIsDownpaymentRetirement401KLoanOrWithdrawal()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownpaymentCheckingOrSavingsAccount);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentRetirement401KLoanOrWithdrawal, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DownpaymentRetirement401KLoanOrWithdrawal_NextQuestionIsDownpaymentSaleOfStockOrBonds()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownpaymentRetirement401KLoanOrWithdrawal);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentSaleOfStockOrBonds, definition.GetNextQuestionId(null));
        }

        [Test]
        public void DownpaymentRetirement401KLoanOrWithdrawalPossibleAnswers_AnswerYes_NextQuestionIsRequestedTheFunds()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownpaymentRetirement401KLoanOrWithdrawal) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RequestedTheFunds, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_RequestedTheFunds_NextQuestionIsDownpaymentSaleOfStockOrBonds()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RequestedTheFunds);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentSaleOfStockOrBonds, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DownpaymentSaleOfStockOrBonds_NextQuestionIsDownpaymentGift()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownpaymentSaleOfStockOrBonds);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentGift, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DownpaymentGift_NextQuestionIsDownpaymentEquityFromPendingSale()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownpaymentGift);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentEquityFromPendingSale, definition.GetNextQuestionId(null));
        }

        [Test]
        public void DownpaymentGiftPossibleAnswers_AnswerYes_NextQuestionIsAmountOfGift()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownpaymentGift) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AmountOfGift, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_AmountOfGift_NextQuestionIsRelationshipOfDonor()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AmountOfGift);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RelationshipOfDonor, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_RelationshipOfDonor_NextQuestionIsReceivedGift()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RelationshipOfDonor);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ReceivedGift, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_ReceivedGift_NextQuestionIsDownpaymentEquityFromPendingSale()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ReceivedGift);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentEquityFromPendingSale, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DownpaymentEquityFromPendingSale_NextQuestionIsOtherSourcesForDownpayment()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownpaymentEquityFromPendingSale);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OtherSourcesForDownpayment, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OtherSourcesForDownpayment_NextQuestionIsDownPaymentBorrowed()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OtherSourcesForDownpayment);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownPaymentBorrowed, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DownPaymentBorrowed_NextQuestionIsChildSupport()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DownPaymentBorrowed);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ChildSupport, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_ChildSupport_NextQuestionIsAlimonyObligation()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ChildSupport);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AlimonyObligation, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_AlimonyObligation_NextQuestionIsRecentDebt()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AlimonyObligation);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RecentDebt, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_RecentDebt_NextQuestionIsFileATaxExtension()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RecentDebt);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.FileATaxExtension, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_FileATaxExtension_NextQuestionIsBackTaxesFromAnyPreviousYears()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.FileATaxExtension);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.BackTaxesFromAnyPreviousYears, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_BackTaxesFromAnyPreviousYears_NextQuestionIsUseOfHomeForBusiness()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.BackTaxesFromAnyPreviousYears);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.UseOfHomeForBusiness, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_UseOfHomeForBusiness_NextQuestionIsUnreimbursedEmployeeExpenses()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.UseOfHomeForBusiness);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.UnreimbursedEmployeeExpenses, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_UnreimbursedEmployeeExpenses_NextQuestionIsOutstandingJudgements()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.UnreimbursedEmployeeExpenses);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OutstandingJudgements, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OutstandingJudgements_NextQuestionIsDeclaredBankrupt()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OutstandingJudgements);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DeclaredBankrupt, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DeclaredBankrupt_NextQuestionIsPropertyForeclosed()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DeclaredBankrupt);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PropertyForeclosed, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_PropertyForeclosed_NextQuestionIsDateOfPropertyForeclosed()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.PropertyForeclosed);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DateOfPropertyForeclosed, definition.GetNextQuestionId(null));
        }


        [Test]
        public void GetDefinition_ObligatedOnAnyLoan_NextQuestionIsUsCitizen()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ObligatedOnAnyLoan);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.UsCitizen, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_UsCitizen_NextQuestionIsCurrentlyPartyToALawsuit()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.UsCitizen);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentlyPartyToALawsuit, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_CurrentlyPartyToALawsuit_NextQuestionIsStatusOfLoanDelinquency()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CurrentlyPartyToALawsuit);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.StatusOfLoanDelinquency, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_StatusOfLoanDelinquency_NextQuestionIsCoMakerOrEndorser()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.StatusOfLoanDelinquency);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CoMakerOrEndorser, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_CoMakerOrEndorser_NextQuestionIsShortSale()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CoMakerOrEndorser);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ShortSale, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_ShortSale_NextQuestionIsDateOfShortSale()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ShortSale);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DateOfShortSale, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DependencyExistancePossiblieAnswerYes_NextQuestionIsNumberOfDependents()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DependencyExistance) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.NumberOfDependents, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void OwnOrRentPossibleAnswers_AnswerOwn_NextQuestionIsOwnMonthlyPayment()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnOrRent) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OwnMonthlyPayment, definition.PossibleAnswers.Find(p => p.AnswerId == 0).NextQuestion);
        }

        [Test]
        public void GetDefinition_OwnMonthlyPayment_NextQuestionIsCurrentHomePlan()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnMonthlyPayment);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentHomePlan, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_CurrentHomePlan_NextQuestionIsWhenBuyHome()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CurrentHomePlan);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.WhenBuyHome, definition.GetNextQuestionId(null));
        }

        [Test]
        public void CurrentHomePlanPossibleAnswers_AnswerUnderAgreement_NextQuestionIsSoldBeforePurchase()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.CurrentHomePlan) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.SoldBeforePurchase, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_SoldBeforePurchase_NextQuestionIsClosingDate()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.SoldBeforePurchase);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ClosingDate, definition.GetNextQuestionId(null));
        }

        [Test]
        public void AuthorizeCreditReportPossibleAnswers_AnswerYes_NextQuestionIsAuthorizeCreditReportName()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.AuthorizeCreditReport) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AuthorizeCreditReportName, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_AuthorizeCreditReportName_NextQuestionIsVeteranLoan()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AuthorizeCreditReportName);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.VeteranLoan, definition.GetNextQuestionId(null));
        }

        [Test]
        public void VeteranLoanPossibleAnswers_AnswerYes_NextQuestionIsMilitaryBranch()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.VeteranLoan) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.MilitaryBranch, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_MilitaryBranch_NextQuestionIsMilitaryBenefits()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.MilitaryBranch);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.MilitaryBenefits, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_MilitaryBenefits_NextQuestionIsPreviousUseOfVaEntitlement()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.MilitaryBenefits);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PreviousUseOfVaEntitlement, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_PreviousUseOfVaEntitlement_NextQuestionIsPercentDisabled()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.PreviousUseOfVaEntitlement);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PercentDisabled, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_PercentDisabled_NextQuestionIsListedAsPermanentlyDisabled()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.PercentDisabled);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ListedAsPermanentlyDisabled, definition.GetNextQuestionId(null));
        }

        [Test]
        public void PercentDisabledPossibleAnswers_AnswerNo_NextQuestionIsTitleHolding()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.PercentDisabled) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TitleHolding, definition.PossibleAnswers.Find(p => p.AnswerId == 0).NextQuestion);
        }

        [Test]
        public void GetDefinition_ListedAsPermanentlyDisabled_NextQuestionIsTitleHolding()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ListedAsPermanentlyDisabled);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TitleHolding, definition.GetNextQuestionId(null));
        }

        [Test]
        public void OwnPropertiesOrLandPossibleAnswers_AnswerYes_NextQuestionIsTypeOfProperty()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnPropertiesOrLand) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TypeOfProperty, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_TypeOfProperty_NextQuestionIsAddressOfPropery()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.TypeOfProperty);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AddressOfProperty, definition.GetNextQuestionId(null));
        }

        [Test]
        public void ChildSupportPossibleAnswers_AnswerYes_NextQuestionIsOneOrMoreParentChildSupport()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.ChildSupport) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OneOrMoreParentChildSupport, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_OneOrMoreParentChildSupport_NextQuestionIsAlimonyObligation()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OneOrMoreParentChildSupport);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AlimonyObligation, definition.GetNextQuestionId(null));
        }

        [Test]
        public void OneOrMoreParentChildSupportPossibleAnswers_AnswerYes_NextQuestionIsNumberOfChildDependents()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.OneOrMoreParentChildSupport) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.NumberOfChildDependents, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_NumberOfChildDependents_NextQuestionIsDurationOfChildSupportObligation()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.NumberOfChildDependents);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DurationOfChildSupportObligation, definition.GetNextQuestionId(null));
        }

        [Test]
        public void BackTaxesFromAnyPreviousYearsPossibleAnswers_AnswerYes_NextQuestionIsPaymentPlan()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.BackTaxesFromAnyPreviousYears) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PaymentPlan, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_PaymentPlan_NextQuestionIsUseOfHomeForBusiness()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.PaymentPlan);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.UseOfHomeForBusiness, definition.GetNextQuestionId(null));
        }

        [Test]
        public void UsCitizenPossibleAnswers_AnswerNo_NextQuestionIsPermanentResident()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.UsCitizen) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PermanentResident, definition.PossibleAnswers.Find(p => p.AnswerId == 0).NextQuestion);
        }

        [Test]
        public void GetDefinition_PermanentResident_NextQuestionIsCurrentlyPartyToALawsuit()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.PermanentResident);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentlyPartyToALawsuit, definition.GetNextQuestionId(null));
        }

        [Test]
        public void PermanentResidentPossibleAnswers_AnswerYes_NextQuestionIsWorkVisa()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.PermanentResident) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.WorkVisa, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_WorkVisa_NextQuestionIsCurrentlyPartyToALawsuit()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.WorkVisa);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentlyPartyToALawsuit, definition.GetNextQuestionId(null));
        }

        [Test]
        public void OwnershipInterestInAPropertyPossibleAnswers_AnswerYes_NextQuestionIsHoldTitle()
        {
            // Arrange
            // Act
            var definition =
                _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnershipInterestInAProperty) as SingleSelectQuestionDefinitionBase;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.HoldTitle, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_HoldTitle_NextQuestionIsTypeOfOwnershipPropety()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.HoldTitle);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TypeOfOwnershipPropety, definition.GetNextQuestionId(null));
        }



        [Test]
        public void GetDefinition_CurrentAddress_NextQuestionIsOwnOrRent()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.CurrentAddress);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OwnOrRent, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_ClosingDate_NextQuestionIsWhenBuyHome()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ClosingDate);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.WhenBuyHome, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_WhenBuyHome_NextQuestionIsPreviousAddress1()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.WhenBuyHome);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PreviousAddress1, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_PreviousAddress1_NextQuestionIsDurationAtPreviousAddress()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.PreviousAddress1);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DurationAtPreviousAddress, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationAtPreviousAddress_NextQuestionIsTimeframeForPurchase()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationAtPreviousAddress);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TimeframeForPurchase, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_AmountOfRent_NextQuestionIsDurationAtCurrentRental()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AmountOfRent);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DurationAtCurrentRental, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationAtCurrentRental_NextQuestionIsPreviousAddress2()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationAtCurrentRental);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PreviousAddress2, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_PreviousAddress2_NextQuestionIsDurationAtPreviousRental()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.PreviousAddress2);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DurationAtPreviousRental, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationAtPreviousRental_NextQuestionIsTimeframeForPurchase()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationAtPreviousRental);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TimeframeForPurchase, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_AgentInfo_NextQuestionIsReccomendAgent()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AgentInfo);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RecommendAgent, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_AddressOfProperty_NextQuestionIsDateOfPropertyPurchase()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AddressOfProperty);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DateOfPropertyPurchase, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DateOfPropertyPurchase_NextQuestionIsCurrentLienHolder()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DateOfPropertyPurchase);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentLienHolder, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DateOfSale_NextQuestionIsAddressOfTheSoldProperty()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DateOfSale);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AddressOfTheSoldProperty, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_AddressOfTheSoldProperty_NextQuestionIsCurrentHouseholdIncome()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.AddressOfTheSoldProperty);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentHouseholdIncome, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationOfSelfEmplyement_NextQuestionIsTypeOfBusiness()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationOfSelfEmplyement);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TypeOfBusiness, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_TypeOfBusiness_NextQuestionIsPercentOfBusinessOwnership()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.TypeOfBusiness);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PercentOfBusinessOwnership, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OwnMoreThan25Percent_NextQuestionIsPercentOfBusinessOwnership()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnMoreThan25Percent);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PercentOfBusinessOwnership, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_BusinessTaxExtension_NextQuestionIsOtherBusinessInterests()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.BusinessTaxExtension);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OtherBusinessInterests, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OtherBusinessInterests_NextQuestionIsEmploymentGaps()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OtherBusinessInterests);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EmploymentGaps, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OtherW2Jobs_NextQuestionIsEmploymentGaps()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OtherW2Jobs);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EmploymentGaps, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_EmployerInfo_NextQuestionIsTimeOfWorkingOvertime()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.EmployerInfo);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.TimeOfWorkingOvertime, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_TimeOfWorkingOvertime_NextQuestionIsEmploymentGaps()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.TimeOfWorkingOvertime);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EmploymentGaps, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationOfChildSupport_NextQuestionIsAlimony()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationOfChildSupport);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.Alimony, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_Alimony_NextQuestionIsDownpaymentCheckingOrSavingsAccount()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.Alimony);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentCheckingOrSavingsAccount, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationOfAlimony_NextQuestionIsDownpaymentCheckingOrSavingsAccount()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationOfAlimony);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DownpaymentCheckingOrSavingsAccount, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationOfChildSupportObligation_NextQuestionIsAlimonyObligation()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationOfChildSupportObligation);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AlimonyObligation, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DurationOfAlimonyObligation_NextQuestionIsRecentDebt()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DurationOfAlimonyObligation);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RecentDebt, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_YearOfBankruptcyDischarge_NextQuestionIsPropertyForeclosed()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.YearOfBankruptcyDischarge);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.PropertyForeclosed, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DateOfPropertyForeclosed_NextQuestionIsObligatedOnAnyLoan()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DateOfPropertyForeclosed);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ObligatedOnAnyLoan, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DateOfShortSale_NextQuestionIsOwnershipInterestInAProperty()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DateOfShortSale);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OwnershipInterestInAProperty, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_OwnershipInterestInAProperty_NextQuestionIsHoldTitle()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OwnershipInterestInAProperty);

            // Assert
            Assert.AreEqual(null, definition.GetNextQuestionId(null));
        }

        [Test]
        public void GetDefinition_DependencyExistance_NextQuestionIsCurrentAddress()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.DependencyExistance);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.CurrentAddress, definition.GetNextQuestionId(null));

        }

        [Test]
        public void GetDefinition_ReceiveChildSupport_NextQuestionIsAlimony()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ReceiveChildSupport);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.Alimony, definition.GetNextQuestionId(null));

        }

        [Test]
        public void GetDefinition_ReceiveChildSupportPossiblieAnswerYes_NextQuestionIsDurationOfChildSupport()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.ReceiveChildSupport) as RadioButtonQuestionDefinition;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DurationOfChildSupport, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_RecentDebtAnswerYes_NextQuestionIsRecentDebtDetails()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RecentDebt) as RadioButtonQuestionDefinition;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.RecentDebtDetails, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_RecentDebt_NextQuestionIsFileATaxExtensions()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.RecentDebt);

            // Assert
            Assert.AreEqual(QuestionDefinitionId.FileATaxExtension, definition.GetNextQuestionId(null));

        }

        [Test]
        public void GetDefinition_AlimonyAnswerYes_NextQuestionIsDurationOfAlimony()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.Alimony) as RadioButtonQuestionDefinition;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.DurationOfAlimony, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_OtherW2JobsAnswerYes_NextQuestionIsEmployerInfo()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OtherW2Jobs) as RadioButtonQuestionDefinition;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.EmployerInfo, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        [Test]
        public void GetDefinition_OtherBusinessInterestsAnswerYes_NextQuestionIsOtherW2Jobs()
        {
            // Arrange
            // Act
            var definition = _questionDefinitionService.GetDefinition(QuestionDefinitionId.OtherBusinessInterests) as RadioButtonQuestionDefinition;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.OtherW2Jobs, definition.PossibleAnswers.Find(p => p.AnswerId == 1).NextQuestion);
        }

        // ReSharper restore InconsistentNaming
        // ReSharper restore PossibleNullReferenceException
    }
}
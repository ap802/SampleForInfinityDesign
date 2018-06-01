using System;
using MySMA.Models;
using NUnit.Framework;

namespace MySMA.Tests.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleNullReferenceException

    [TestFixture]
    public class QuestionDefinitionIdTests
    {
        private enum FrozenQuestionDefinitionId
        {
            //Single select
            CurrentLienHolder = 0,
            MaritalStatus = 1,
            GraduatedFromCollege = 2,
            DependencyExistance = 3,
            OwnOrRent = 4,
            TimeframeForPurchase = 5,
            CurrentRealEstateAgent = 6,
            IntentionForTheNewProperty = 7,
            TermsApplyingFor = 8,
            CreditRating = 9,
            AuthorizeCreditReport = 10,
            VeteranLoan = 11,
            TitleHolding = 12,
            EscrowTaxesInTheLoan = 13,
            EscrowHazardInsuranceInLoan = 14,
            OverdraftFeesOnBankStatements = 15,
            RetirementAccountsOr401Ks = 16,
            OwnPropertiesOrLand = 17,
            RecentlySoldProperties = 18,
            SelfEmployed = 19,
            EmploymentGaps = 20,
            DownPaymentBorrowed = 21,
            ChildSupport = 22,
            AlimonyObligation = 23,
            RecentDebt = 24,
            BackTaxesFromAnyPreviousYears = 25,
            UseOfHomeForBusiness = 26,
            UnreimbursedEmployeeExpenses = 27,
            OutstandingJudgements = 28,
            DeclaredBankrupt = 29,
            PropertyForeclosed = 30,
            PartyToALawsuit = 31,
            ObligatedOnAnyLoan = 32,
            UsCitizen = 33,
            CurrentlyPartyToALawsuit = 34,
            StatusOfLoanDelinquency = 35,
            CoMakerOrEndorser = 36,
            ShortSale = 37,
            OwnershipInterestInAProperty = 38,
            FileATaxExtension = 44,

            BorrowerDateOfBirth = 39,
            PropertyTypes = 40,
            BorrowerAge = 41,
            SpouseAge = 42,
            ChildAge = 43
        }

        /// <summary>
        /// DO NOT CHANGE THIS TEST
        /// Changing this test (or changing original QuestionDefinitionId enum values)
        /// will broke whole system.
        /// </summary>
        [Test]
        public void QuestionDefinitionId_GetValue_EnumIsValid()
        {
            // Arrange            
            // Act
            // Assert

            var frozenValues = Enum.GetValues(typeof (FrozenQuestionDefinitionId));
            var currentValues = Enum.GetValues(typeof (QuestionDefinitionId));

            for (var i = 0; i < frozenValues.Length; i++)
            {
                Assert.AreEqual((int)frozenValues.GetValue(i), (int)currentValues.GetValue(i));
            }
        }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore PossibleNullReferenceException
}
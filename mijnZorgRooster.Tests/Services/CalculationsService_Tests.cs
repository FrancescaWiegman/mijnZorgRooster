using System;
using Xunit;
using mijnZorgRooster.Services;
using System.Collections.Generic;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.Tests
{
	public class CalculationsService_Tests
	{
		private readonly Services.CalculationsService _calculationsService;

		public CalculationsService_Tests()
		{
			_calculationsService = new Services.CalculationsService(null);
		}

		[Fact]
		public void BerekenLeeftijdInJaren_DateTime_ReturnsInteger()
		{
			// TODO: Deze test is eigenlijk niet goed omdat hij niet repeatable is. Na 17 september klopt hij niet meer.
			var result = _calculationsService.BerekenLeeftijdInJaren(DateTime.Parse("17 september 1977"));

			Assert.True(result == 41);
		}

		[Theory]
		[MemberData(nameof(PercentageSets))]
		public void BerekenParttimePercentage_Int_ReturnsInt(int contractUren, int verwachtPercentage)
		{
			var result = _calculationsService.BerekenParttimePercentage(contractUren);
			Assert.True(result == verwachtPercentage);
		}

		public static IEnumerable<object[]> PercentageSets =>
		new List<object[]>
	   {
			new object[] { 36, 100 },
			new object[] { 32, 88 },
			new object[] { 20, 55 },
			new object[] { 16, 44 }
	   };


		[Fact]
		public void BerekenVakantieDagen_MetEinddatumSet_ContractDTO_ReturnsFloat()
		{
			// Arrange
			var contract = new Contract
			{
				ContractID = 1,
				BeginDatum = DateTime.Parse("25-1-2006"),
				Einddatum = DateTime.Parse("28-03-2019"),
				ContractUren = 36
			};
			var contractDTO = new ContractDTO(contract);

			// Act
			var result = _calculationsService.BerekenVakantieDagen(contractDTO);

			// Assert
			Assert.True(result == 385.77500000000003);
		}

		[Fact]
		public void BerekenVakantieDagen_ZonderEinddatumSet_ContractDTO_ReturnsFloat()
		{
			// Arrange
			var contract = new Contract
			{
				ContractID = 4,
				BeginDatum = DateTime.Parse("25-1-2016"),
				ContractUren = 36
			};
			var contractDTO = new ContractDTO(contract);

			// Act
			var result = _calculationsService.BerekenVakantieDagen(contractDTO);

			// Assert
			Assert.True(result == 89.025);
		}
	}
}

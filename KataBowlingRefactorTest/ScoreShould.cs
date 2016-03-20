using FluentAssertions;
using KataBowlingTwo;
using NUnit.Framework;


namespace KataBowlingTwoTest
{
	[TestFixture]
	class ScoreShould
	{
		[Test]
		public void sum_single_rolls()
		{
			Score.For("--------------------").Should().Be(0);
			Score.For("---1--1---11--1111--").Should().Be(8);
		}

		[Test]
		public void sum_spare_rolls()
		{
			Score.For("-/------------------").Should().Be(10);
			Score.For("-/1-----------------").Should().Be(12);
			Score.For("1/1-----------------").Should().Be(12);
		}

		[Test]
		public void sum_strike_rolls()
		{
			Score.For("X------------------").Should().Be(10);
			Score.For("X-1----------------").Should().Be(12);
			Score.For("X1-----------------").Should().Be(12);
			Score.For("X11----------------").Should().Be(14);
		}

		[Test]
		public void acceptance_test_with_only_normal_rolls()
		{
			Score.For("11111111111111111111").Should().Be(20);
		}

		[Test]
		public void acceptance_test_without_spares_and_strikes()
		{
			Score.For("9-9-9-9-9-9-9-9-9-9-").Should().Be(90);
		}

		[Test]
		public void acceptance_test_with_all_spares()
		{
			Score.For("5/5/5/5/5/5/5/5/5/5/5").Should().Be(150);
		}

		[Test]
		public void acceptance_test_with_all_strikes()
		{
			Score.For("XXXXXXXXXXXX").Should().Be(300);
		}

		[Test]
		public void acceptance_test_with_every_possible_roll()
		{
			Score.For("-/1-XX1/X-/-11-X-/").Should().Be(125);
			Score.For("-/1-XX1/X-/-11-XX5").Should().Be(130);
		}
	}
}

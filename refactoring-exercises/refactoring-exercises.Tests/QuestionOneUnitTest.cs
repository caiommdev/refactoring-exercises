﻿namespace One.Tests;

public class ValueClassifierTests
{
    private readonly ValueClassifier _classifier;

    public ValueClassifierTests()
    {
        _classifier = new ValueClassifier();
    }

    [Fact]
    public void ClassifyValue_WithHighValue_ReturnsAlto()
    {
        // Arrange
        int highValue = 15;

        // Act
        string result = _classifier.ClassifyValue(highValue);

        // Assert
        Assert.Equal("ALTO", result);
    }

    [Fact]
    public void ClassifyValue_WithMediumValue_ReturnsMedio()
    {
        // Arrange
        int mediumValue = 10;

        // Act
        string result = _classifier.ClassifyValue(mediumValue);

        // Assert
        Assert.Equal("MÉDIO", result);
    }

    [Fact]
    public void ClassifyValue_WithLowValue_ReturnsBaixo()
    {
        // Arrange
        int lowValue = 5;

        // Act
        string result = _classifier.ClassifyValue(lowValue);

        // Assert
        Assert.Equal("BAIXO", result);
    }

    [Fact]
    public void ClassifyValue_WithSpecialErrorValue_ReturnsCasoRaro()
    {
        // Arrange
        int specialErrorValue = -9999;

        // Act
        string result = _classifier.ClassifyValue(specialErrorValue);

        // Assert
        Assert.Equal("CASO RARO", result);
    }

    [Theory]
    [InlineData(11)]
    [InlineData(100)]
    [InlineData(1000)]
    public void ClassifyValue_WithValuesAboveTen_ReturnsAlto(int value)
    {
        // Act
        string result = _classifier.ClassifyValue(value);

        // Assert
        Assert.Equal("ALTO", result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(9)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void ClassifyValue_WithValuesBelowTen_ReturnsBaixo(int value)
    {
        // Act
        string result = _classifier.ClassifyValue(value);

        // Assert
        Assert.Equal("BAIXO", result);
    }

    [Fact]
    public void PrintClassification_WithAnyValue_PrintsCorrectClassification()
    {
        // Arrange
        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);
        int testValue = 10;

        // Act
        _classifier.PrintClassification(testValue);

        // Assert
        string output = sw.ToString().Trim();
        Assert.Equal("MÉDIO", output);
    }
}

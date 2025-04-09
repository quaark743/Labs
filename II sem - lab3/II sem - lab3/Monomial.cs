using System.Text.Json.Serialization;

public class Monomial
{
    [JsonInclude]
    private double coefficient;
    private int degree;

    public double Coefficient
    {
        get { return coefficient; }

        set { coefficient = value; }
    }
    public int Degree
    {
        get { return degree; }

        set { degree = value; }
    }
    public Monomial(double coefficient, int degree)
    {
        this.coefficient = coefficient;
        this.degree = degree;
    }
    public static Monomial Multiply(Monomial m1, Monomial m2)
    { 
        return new Monomial(m1.coefficient * m2.coefficient, m1.degree + m2.degree);
    }

    public static Monomial Divide(Monomial m1, Monomial m2)
    {
        return new Monomial(m1.coefficient / m2.coefficient, m1.degree - m2.degree);
    }
    public override string ToString()
    {
        if (Coefficient == 0)
            return "";

        string coefStr = Coefficient == 1 && Degree != 0 ? "" : Coefficient == -1 && Degree != 0 ? "-" : Coefficient.ToString();
        string degreeStr = Degree == 0 ? "" : Degree == 1 ? "x" : $"x^{Degree}";
        return coefStr + degreeStr;
    }
}


using System.Text;
using System.Text.Json.Serialization;

public class Polynomial
{
    [JsonInclude]
    private List<Monomial> polynomial;
    public List<Monomial> Polynom
    {
        get { return polynomial; }

        set { polynomial = value; }
    }
    public Polynomial(List<Monomial> polynomial)
    {
        this.polynomial = polynomial;
    }
    public bool Contains(Monomial m)
    {
        return polynomial.Any(mon => mon.Coefficient == m.Coefficient && mon.Degree == m.Degree);
    }
    public void Simplify()
    {
        Dictionary<int, double> grouped = new Dictionary<int, double>();

        foreach (var m in polynomial)
        {
            if (grouped.ContainsKey(m.Degree))
                grouped[m.Degree] += m.Coefficient;
            else
                grouped[m.Degree] = m.Coefficient;
        }

        polynomial = grouped
            .Where(pair => pair.Value != 0)
            .Select(pair => new Monomial(pair.Value, pair.Key))
            .ToList();
    }
    public static Polynomial Add(Polynomial p1, Polynomial p2)
    {
        List<Monomial> all = new List<Monomial>();
        all.AddRange(p1.polynomial);
        all.AddRange(p2.polynomial);

        Polynomial result = new Polynomial(all);

        result.Simplify();

        return result;
    }

    public static Polynomial Subtract(Polynomial p1, Polynomial p2)
    {
        List<Monomial> all = new List<Monomial>();
        all.AddRange(p1.polynomial);

        foreach (var m in p2.polynomial)
        {
            all.Add(new Monomial(-m.Coefficient, m.Degree));
        }

        Polynomial result = new Polynomial(all);

        result.Simplify();

        return result;
    }
    public static Polynomial Multiply(Polynomial p1, Polynomial p2)
    {
        List<Monomial> result = new List<Monomial>();
        foreach (var m1 in p1.polynomial)
        {
            foreach (var m2 in p2.polynomial)
            {
                result.Add(Monomial.Multiply(m1, m2));
            }
        }
        return new Polynomial(result);
    }
    public static (Polynomial quotient, Polynomial remainder) Divide(Polynomial dividend, Polynomial divisor)
    {
        List<Monomial> quotient = new List<Monomial>();
        Polynomial remainder = new Polynomial(new List<Monomial>(dividend.polynomial));

        remainder.polynomial = remainder.polynomial.OrderByDescending(m => m.Degree).ToList();
        divisor.polynomial = divisor.polynomial.OrderByDescending(m => m.Degree).ToList();

        while (remainder.polynomial.Count > 0 && remainder.polynomial[0].Degree >= divisor.polynomial[0].Degree)
        {
            var leadR = remainder.polynomial[0];
            var leadD = divisor.polynomial[0];

            Monomial div = Monomial.Divide(leadR, leadD);
            quotient.Add(div);

            Polynomial subtractPart = Multiply(new Polynomial(new List<Monomial> { div }), divisor);
            remainder = Subtract(remainder, subtractPart);
        }

        return (new Polynomial(quotient), remainder);
    }

    public static bool AreEqual(Polynomial p1, Polynomial p2)
    {
        if (p1.polynomial.Count != p2.polynomial.Count)
            return false;

        for (int i = 0; i < p1.polynomial.Count; i++)
        {
            if (p1.polynomial[i].Degree != p2.polynomial[i].Degree ||
                p1.polynomial[i].Coefficient != p2.polynomial[i].Coefficient)
            {
                return false;
            }
        }
        return true;
    }
    public override string ToString()
    {
        if (!polynomial.Any()) return "0";

        StringBuilder sb = new StringBuilder();
        foreach (var m in polynomial.OrderByDescending(m => m.Degree))
        {
            double c = m.Coefficient;
            if (sb.Length > 0 && c > 0)
                sb.Append("+");
            sb.Append(m.ToString());
        }
        return sb.ToString();
    }
}



namespace MightyXOR.Core.SecretSharing.Shamir;

/// <summary>
/// A share (point on the plane) consisting of two Galois <see cref="Field">fields</see>.
/// </summary>
public class Share
{
    private readonly Tuple<Field, Field> _point;
    public Field X => _point.Item1;
    public Field Y => _point.Item2;

    /// <summary>
    /// Default constructor creating the point (0,0)
    /// </summary>
    public Share()
    {
        var x = new Field(0);
        var y = new Field(0);

        _point = new Tuple<Field, Field>(x, y);
    }

    /// <summary>
    /// Constructs a share from another share
    /// </summary>
    public Share(Share share)
    {
        _point = new Tuple<Field, Field>(share.X, share.Y);
    }

    /// <summary>
    /// Constructs a share from two <see cref="Field">fields</see>
    /// </summary>
    public Share(Field x, Field y)
    {
        _point = new Tuple<Field, Field>(x, y);
    }
}
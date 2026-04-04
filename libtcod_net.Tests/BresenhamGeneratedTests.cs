using static libtcod.Interop.libtcod;

namespace libtcod_net.Tests;

public class BresenhamGeneratedTests
{
    [Fact]
    public void LineStepMt_MatchesNativeExpectedSequence()
    {
        Assert.Equal(
            new (int X, int Y)[]
            {
                (0, 0),
                (1, 0),
                (2, 1),
                (3, 1),
                (4, 1),
                (5, 1),
                (6, 2),
                (7, 2),
                (8, 2),
                (9, 2),
                (10, 3),
                (11, 3),
            },
            GenerateLine((0, 0), (11, 3))
        );
    }

    [Fact]
    public void LineStepMt_MatchesNativeExpectedSequenceInReverse()
    {
        Assert.Equal(
            new (int X, int Y)[]
            {
                (11, 3),
                (10, 3),
                (9, 2),
                (8, 2),
                (7, 2),
                (6, 2),
                (5, 1),
                (4, 1),
                (3, 1),
                (2, 1),
                (1, 0),
                (0, 0),
            },
            GenerateLine((11, 3), (0, 0))
        );
    }

    private static IReadOnlyList<(int X, int Y)> GenerateLine(
        (int X, int Y) begin,
        (int X, int Y) end
    )
    {
        var data = new TCOD_bresenham_data_t();
        var x = begin.X;
        var y = begin.Y;
        var line = new List<(int X, int Y)> { begin };

        TCOD_line_init_mt(begin.X, begin.Y, end.X, end.Y, out data);
        while (!TCOD_line_step_mt(ref x, ref y, ref data))
        {
            line.Add((x, y));
        }

        return line;
    }
}

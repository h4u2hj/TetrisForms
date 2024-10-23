namespace TetrisModel.Persistence;

public interface ITetrisDataAccess
{
    GameGrid Load(String path);
    void Save(String path, GameGrid grid, int score);
    int LoadScore(string fileName);
}
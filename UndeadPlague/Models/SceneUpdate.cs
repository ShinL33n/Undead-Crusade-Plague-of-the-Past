using Microsoft.Xna.Framework;

namespace UndeadPlague.Models;
public abstract partial class Scene
{
    public abstract void LoadContent();
    public abstract void Update(GameTime gameTime);
    public abstract void Draw();

}
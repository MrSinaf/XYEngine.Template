using XYEngine.Resources;
using XYEngine.UI.Widgets;

namespace XYEngine.Template;

public class FirstScene : Scene
{
	protected override void Start()
	{
		/* Code exécuté à l'initialisation de la scène. */

		// Défini le fond à une couleur personnalisée (par-défaut : noir) et le met en mode fenêtré :
		Graphics.SetBackgroundColor(new Color(20, 20, 35));
		GameWindow.SetDisplayMode(DisplayMode.Windowed);

		// Création de l'interface utilisateur :
		var panel = new Panel { size = new Vector2Int(300, 400), pivotAndAnchors = new Vector2(0.5F), tint = new Color(35, 35, 55) };
		canvas.root.AddChild(panel); // canvas.root, permet d'accèder à l'UIElement principal de notre scène.

		var layout = new Layout { vertical = true, spacing = 30, alignment = 0.5F, pivotAndAnchors = new Vector2(0.5F, 1), position = new Vector2Int(0, -20) };
		layout.AddChild(new Image(AssetManager.GetEmbeddedAsset<Texture2D>("textures.xy.png")));
		layout.AddChild(new Label("Ma première scène !", AssetManager.GetEmbeddedAsset<Font>("fonts.jetbrains.ttf").GetBitmap(16)));
		panel.AddChild(layout);

		panel.AddChild(new Button("Quitter", GameWindow.Close) { pivotAndAnchors = new Vector2(0.5F, 0), position = new Vector2Int(0, 20) });
	}

	protected override void Update()
	{
		/* Logique à ajouter dans la boucle principal de la scène. */
	}
}
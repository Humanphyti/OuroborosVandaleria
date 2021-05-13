using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosVandaleriaCore.Engine.Sprite
{
    public class SpriteSheet : IEnumerable<TextureRegion2D>
    {
        private readonly Dictionary<string, TextureRegion2D> regionsByName;
        private readonly List<TextureRegion2D> regionsByIndex;

        public string Name { get; }
        public Texture2D Texture { get; }
        public IEnumerable<TextureRegion2D> Regions => regionsByIndex;
        public int RegionCount => regionsByIndex.Count;
        public TextureRegion2D this[string name] => GetRegion(name);
        public TextureRegion2D this[int index] => GetRegion(index);



        public IEnumerator<TextureRegion2D> GetEnumerator()
        {
            return regionsByIndex.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SpriteSheet(string name, Texture2D texture)
        {
            Name = name;
            Texture = texture;

            regionsByName = new Dictionary<string, TextureRegion2D>();
            regionsByIndex = new List<TextureRegion2D>();
        }

        public SpriteSheet(string name, Texture2D texture, Dictionary<string, Rectangle> regions) : this(name, texture)
        {
            foreach (var region in regions)
                CreateRegion(region.Key, region.Value.X, region.Value.Y, region.Value.Width, region.Value.Height);
        }

        public bool ContainsRegion(string name)
        {
            return regionsByName.ContainsKey(name);
        }

        private void AddRegion(TextureRegion2D region)
        {
            regionsByIndex.Add(region);
            regionsByName.Add(region.Name, region);
        }

        public TextureRegion2D CreateRegion(string name, int x, int y, int width, int height)
        {
            if (regionsByName.ContainsKey(name))
                throw new InvalidOperationException($"Region {name} already exists in the spritesheet");

            var region = new TextureRegion2D(name, Texture, x, y, width, height);
            AddRegion(region);
            return region;
        }

        public void RemoveRegion(int index)
        {
            var region = regionsByIndex[index];
            regionsByIndex.RemoveAt(index);

            if (region.Name != null)
                regionsByName.Remove(region.Name);
        }

        public void RemoveRegion(string name)
        {
            if(regionsByName.TryGetValue(name, out var region))
            {
                regionsByName.Remove(name);
                regionsByIndex.Remove(region);
            }
        }

        public TextureRegion2D GetRegion(int index)
        {
            if (index < 0 || index >= regionsByIndex.Count)
                throw new IndexOutOfRangeException();

            return regionsByIndex[index];
        }

        public TextureRegion2D GetRegion(string name)
        {
            return GetRegion<TextureRegion2D>(name);
        }

        public T GetRegion<T>(string name) where T : TextureRegion2D
        {
            if (regionsByName.TryGetValue(name, out var region))
                return (T)region;

            throw new KeyNotFoundException(name);
        }

        public static SpriteSheet Create(string name, Texture2D texture, int regionWidth, int regionHeight, int MaxRegionCount = int.MaxValue, int margin = 0, int spacing = 0)
        {
            var spriteSheet = new SpriteSheet(name, texture);
            var count = 0;
            var width = texture.Width - margin;
            var height = texture.Height - margin;
            var xIncrement = regionWidth + spacing;
            var yIncrement = regionHeight + spacing;

            for (var y = margin; y < height; y += yIncrement)
            {
                for (var x = margin; x < width; x += xIncrement)
                {
                    var regionName = $"{texture.Name ?? "region"}{count}";
                    spriteSheet.CreateRegion(regionName, x, y, regionWidth, regionHeight);
                    count++;

                    if (count >= MaxRegionCount)
                        return spriteSheet;
                }
            }
            return spriteSheet;
        }
    }
}

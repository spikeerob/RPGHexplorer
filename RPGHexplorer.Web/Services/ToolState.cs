using System;

namespace RPGHexplorer.Web.Services
{
    public enum ToolType
    {
        View,
        Terrain,
    }
    
    public class ToolState
    {
        public ToolType CurrentTool { get; private set; }

        public bool IsDragging { get; private set; }
        
        public string CurrentTerrainTypeId { get; private set; }
        
        public bool IsView => CurrentTool == ToolType.View;
        public bool IsTerrain => CurrentTool == ToolType.Terrain;

        public event Action OnToolChange; 
        
        public void ToView()
        {
            SetCurrentTool(ToolType.View);
        }

        public void ToTerrain()
        {
            SetCurrentTool(ToolType.Terrain);
        }

        private void SetCurrentTool(ToolType toolType)
        {
            CurrentTool = toolType;
            OnToolChange?.Invoke();
        }

        public void SelectTerrain(string terrainTypeId)
        {
            CurrentTerrainTypeId = terrainTypeId;
        }

        public void StartDragging()
        {
            IsDragging = true;
        }

        public void StopDragging()
        {
            IsDragging = false;
        }
    }
}
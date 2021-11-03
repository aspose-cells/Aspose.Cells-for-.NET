using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace CellsExplorer
{
    internal class CellsNode
    {
        public CellsNode()
        {
            this.NodeId = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.ChildList = new ObservableCollection<CellsNode>();
        }
       
        public string NodeId { get; set; }

        public string NodeName { get; set; }

      
        public string NodeContent { get; set; }

        public bool IsDeleted { get; set; }

     
        public CellsNodeType NodeType { get; set; }

        public ObservableCollection<CellsNode> ChildList { get; set; }

        public void AddChild(CellsNode node)
        {
            if (ChildList != null)
            {
                ChildList.Add(node);
            }
            
        }

    }
}

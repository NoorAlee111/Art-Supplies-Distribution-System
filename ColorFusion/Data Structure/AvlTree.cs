using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColourFusion.BL;
using ColourFusion.DL;
using System.IO;

namespace ColorFusion.DataStructure
{
    class Node
    {
        public Product Product;
        public Node Left;
        public Node Right;

        public Node(Product Product)
        {
            this.Product = Product;
        }
        public Node()
        {
           
        }
    }

    class AvlTree
    {
        private Node Root;

        public Node Root1 { get => Root; set => Root = value; }

        public AvlTree()
        {
            this.Root = null;
        }

        public void AddintoAVL(Product Product)
        {
            Node NewItem = new Node(Product);
            this.Root = InsertinTree(this.Root, NewItem);



        }

        public void Write(Node p)
        {
            if (p != null)
            {
                File.WriteAllText("ProductsData.csv", $"{p.Product.ProductId1},{p.Product.Name1},{p.Product.Color1},{p.Product.Liters1},{p.Product.Type1},{p.Product.Quantity1},{p.Product.Threshold1},{p.Product.Supplier1},{p.Product.Price1}" + Environment.NewLine);
                Write(p.Left);
                Write(p.Right);
            }
        }
        public List<Product> GetAvlData(List<Product> list, Node p)
        {

            if (p != null)
            {
                list.Add(p.Product);
                GetAvlData(list, p.Left);
                GetAvlData(list, p.Right);
            }
            return list;
        }
        public Node InsertinTree(Node Root, Node NewNode)
        {
            if (Root == null)
            {
                return NewNode;
            }

            else if (NewNode.Product.ProductId1 < Root.Product.ProductId1)
            {
                Root.Left = InsertinTree(Root.Left, NewNode);

            }
            else if (NewNode.Product.ProductId1 > Root.Product.ProductId1)
            {
                Root.Right = InsertinTree(Root.Right, NewNode);

            }
            Root = BalanceTree(Root);
            return Root;
        }

        public Node BalanceTree(Node Root)
        {
            int BFactor = BalanceFactor(Root);
            if (BFactor > 1)
            {
                if (BalanceFactor(Root.Left) > 0)
                {
                    Root = RotateLL(Root);
                }
                else
                {
                    Root = RotateLR(Root);
                }
            }
            else if (BFactor < -1)
            {
                if (BalanceFactor(Root.Right) > 0)
                {
                    Root = RotateRL(Root);
                }
                else
                {
                    Root = RotateRR(Root);
                }
            }
            return Root;
        }

        public int GetHeight(Node Root)
        {
            int Height = 0;
            if (Root != null)
            {
                int L = GetHeight(Root.Left);
                int R = GetHeight(Root.Right);
                int M = Max(L, R);
                Height = M + 1;
            }
            return Height;
        }

        public int Max(int L, int R)
        {
            if (L > R)
            {
                return L;
            }
            else
            {
                return R;
            }

        }

        public int BalanceFactor(Node Root)
        {
            int Left = GetHeight(Root.Left);
            int Right = GetHeight(Root.Right);
            int BFactor = Left - Right;
            return BFactor;
        }

        public Node RotateRR(Node Parent)
        {
            Node Pivot = Parent.Right;
            Parent.Right = Pivot.Left;
            Pivot.Left = Parent;
            return Pivot;
        }

        public Node RotateLL(Node Parent)
        {
            Node Pivot = Parent.Left;
            Parent.Left = Pivot.Right;
            Pivot.Right = Parent;
            return Pivot;
        }

        public Node RotateLR(Node Parent)
        {
            Node Pivot = Parent.Left;
            Parent.Left = RotateRR(Pivot);
            return RotateLL(Parent);
        }

        public Node RotateRL(Node Parent)
        {
            Node Pivot = Parent.Right;
            Parent.Right = RotateLL(Pivot);
            return RotateRR(Parent);
        }

        public void Delete(Product Target)
        {
            Root = DeletefromAvl(Root, Target);
        }

        public Node DeletefromAvl(Node Root, Product Target)
        {
            Node Parent;
            if (Root == null)
            {
                return null;
            }
            else
            {
                //left subtree
                if (Target.ProductId1 < Root.Product.ProductId1)
                {
                    Root.Left = DeletefromAvl(Root.Left, Target);
                    if (BalanceFactor(Root) == -2)//here
                    {
                        if (BalanceFactor(Root.Right) <= 0)
                        {
                            Root = RotateRR(Root);
                        }
                        else
                        {
                            Root = RotateRL(Root);
                        }
                    }
                }
                //right subtree
                else if (Target.ProductId1 > Root.Product.ProductId1)
                {
                    Root.Right = DeletefromAvl(Root.Right, Target);
                    if (BalanceFactor(Root) == 2)
                    {
                        if (BalanceFactor(Root.Left) >= 0)
                        {
                            Root = RotateLL(Root);
                        }
                        else
                        {
                            Root = RotateLR(Root);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (Root.Right != null)
                    {
                        //delete its inorder successor
                        Parent = Root.Right;
                        while (Parent.Left != null)
                        {
                            Parent = Parent.Left;
                        }
                        Root.Product.ProductId1 = Parent.Product.ProductId1;
                        Root.Right = DeletefromAvl(Root.Right, Parent.Product);
                        if (BalanceFactor(Root) == 2)//rebalancing
                        {
                            if (BalanceFactor(Root.Left) >= 0)
                            {
                                Root = RotateLL(Root);
                            }
                            else { Root = RotateLR(Root); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return Root.Left;
                    }
                }
            }
            return Root;
        }

        public Product Find(int Key)
        {
            Node ObjectGet = new Node();
            ObjectGet = SearchinAvl(Key, Root);
            if (ObjectGet.Product.ProductId1 == Key)
            {
                return ObjectGet.Product;
            }
            else
            {
                return null;
            }
        }

        public Node SearchinAvl(int Target, Node Root)
        {
            if (Target == Root.Product.ProductId1)
            {
                return Root;
            }

            if (Target < Root.Product.ProductId1)
            {

                return SearchinAvl(Target, Root.Left);
            }
            else
            {
                return SearchinAvl(Target, Root.Right);
            }
        }

        /*public void PreOrderTraversal(Node Node)
        {
            if (Node != null)
            {
                PreOrderTraversal(Node.left);
                PreOrderTraversal(Node.right);
            }
        }*/
    }
}

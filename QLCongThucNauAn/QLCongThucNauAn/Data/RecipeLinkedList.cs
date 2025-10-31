﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCongThucNauAn.Data
{
    internal class RecipeLinkedList
    {
        public RecipeNode Head { get; set; } //tro toi nut dau tien cua ds
        public void Add(Recipe recipe) //them node cuoi ds
        {
            RecipeNode newNode = new RecipeNode(recipe);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                RecipeNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

    }
}

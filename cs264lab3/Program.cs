using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyNamespace
{
    class Shapes
    {
        //Interface for all shapes
        public interface Shape
        {
            string ToString();
        }
        //Circle Class
        public class Circle : Shape
        {
            public int radius { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public Circle(int x, int y, int radius)
            {
                this.x = x;
                this.y = y;
                this.radius = radius;
            }
            public override string ToString()
            {
                return "<circle cx=\"" + x + "\" cy=\"" + y + "\" r= \"" + radius + "\" />";
            }
        }
        //Rectangle Class
        public class Rectangle : Shape
        {
 
            public int x { get; set; }
            public int y { get; set; }
            public Rectangle(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
 
            public override string ToString()
            {
                return "<rect x=\"" + x + "\" y=\"" + y + "\" width=\"100\" height=\"100\" />";
            }
        }
        //Ellipse Class
        public class Ellipse : Shape
        {
            public int rx { get; set; }
            public int ry { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public Ellipse(int x, int y, int rx, int ry)
            {
                this.x = x;
                this.y = y;
                this.rx = rx;
                this.ry = ry;
            }
 
            public override string ToString()
            {
                return "<ellipse cx=\"" + x + "\" cy=\"" + y + "\" rx=\"" + rx + "\" ry=\"" + ry + "\" />";
            }
        }
        //Line Class
        public class Line : Shape
        {
            public int x1 { get; set; }
            public int y1 { get; set; }
            public int x2 { get; set; }
            public int y2 { get; set; }
            public Line(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
            public override string ToString()
            {
                return "<line x1=\"" + x1 + "\" y1=\"" + y1 + "\" x2=\"" + x2 + "\" y2=\"" + y2 + "\" />";
            }
        }
        //PolyLine Class
        public class Polyline : Shape
        {
            public int x1 { get; set; }
            public int y1 { get; set; }
            public int x2 { get; set; }
            public int y2 { get; set; }
            public int x3 { get; set; }
            public int y3 { get; set; }
            public int x4 { get; set; }
            public int y4 { get; set; }
            public Polyline(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;
                this.x4 = x4;
                this.y4 = y4;
            }
 
            public override string ToString()
            {
                return "<polyline points=\"" + x1 + "," + y1 + " " + x2 + "," + y2 + " " + x3 + "," + y3 + " " + x4 + "," + y4 + "\" />";
            }
        }
        //Polygon Class
        public class Polygon : Shape
        {
            public int x1 { get; set; }
            public int y1 { get; set; }
            public int x2 { get; set; }
            public int x3 { get; set; }
            public int y2 { get; set; }
            public int y3 { get; set; }
            public int x4 { get; set; }
            public int y4 { get; set; }
            public Polygon(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;
                this.x4 = x4;
                this.y4 = y4;
            }
 
            public override string ToString()
            {
                return "<polygon points=\"" + x1 + "," + y1 + " " + x2 + "," + y2 + " " + x3 + "," + y3 + " " + x4 + "," + y4 + "\" />";
            }
        }
        //Path Class
        public class Path : Shape
        {
            public int x1 { get; set; }
            public int y1 { get; set; }
            public int x2 { get; set; }
            public int y2 { get; set; }
            public int x3 { get; set; }
            public int y3 { get; set; }
            public int x4 { get; set; }
            public int y4 { get; set; }
            public Path(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;
                this.x4 = x4;
                this.y4 = y4;
            }
 
            public override string ToString()
            {
                return "<path d=\"M" + x1 + "," + y1 + " L" + x2 + "," + y2 + " L" + x3 + "," + y3 + " L" + x4 + "," + y4 + " Z\" />";
            }
        }
    // This is memento class
    public class Memento
    {
        public string shape;
        public Memento(string data)
        {
            this.shape=data;
        }
        public string getData(){
            return this.shape;
        }
    }
    // https://www.letsdevelopgames.com/2022/01/memento-design-pattern-for-undoredo.html?m=1
    // This is caretaker class
        public class canvas{
            List<Memento> undoStates = new List<Memento>();
            List<Memento> redoHistory = new List<Memento>();
            public canvas(){
                undoStates = new List<Memento>();
                redoHistory = new List<Memento>();
            }
            //Redo
            public void redo(){
                if(redoHistory.Count > 0){
                    undoStates.Add(redoHistory[redoHistory.Count - 1]);
                    redoHistory.RemoveAt(redoHistory.Count - 1);
                }
            
            }
            //Add
            public void addMenento(Memento newshape){
                undoStates.Add(newshape);
            }
            //Undo
            public void removeMenento()
            {
                if(undoStates.Count > 0){
                    redoHistory.Add(undoStates[undoStates.Count - 1]);
                    undoStates.RemoveAt(undoStates.Count - 1);
                }
            }
            //Get Mememto
            public Memento getMemento(int index){
                return undoStates[index];
            }
            public List<Memento> getUndoStates()
            {
                return this.undoStates;
            }
            public void clearCanvas(){
                undoStates.Clear();
                redoHistory.Clear();
            }
        }
        //This is the originator class
        static void Main(string[] args)
        {
            canvas canvas1 = new canvas();
            Console.WriteLine( canvas1.getUndoStates());
           
            string svgOpen = @"<svg height=""400"" width=""400"" xmlns=""http://www.w3.org/2000/svg"">" + Environment.NewLine;
            string svgClose = Environment.NewLine + @"</svg>";

            bool exit = false;
            Console.Clear();
            while (exit == false)
            {
                Console.WriteLine("Canvas created - use commands to add shapes to canvas");
                
                char command = char.Parse(Console.ReadLine());
                if(command == 'H' || command == 'h'){
                    Console.WriteLine("Commands:\n H	 	 Help  \nA	<shape>	 Add	<shape	to	canvas	  \n D   - Display Canvas \nU	 	 Undo	last	operation	 \n R	 	 Redo	last	operation	 \n C	 	 Clear	canvas	 \n Q	 	 Quit	application");
                }
                else if(command == 'A' || command == 'a'){
                    //Add shape
                    Console.WriteLine("Enter shape type: R for rectangle, C for circle, L for line, P for polygon, S for polyline, or T for path");
                    char shapeType = char.Parse(Console.ReadLine());
                    if(shapeType == 'R'  || shapeType == 'r'){
                        //Rectangle
                        Console.WriteLine("Enter x coordinate");
                        int x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter y coordinate");
                        int y = int.Parse(Console.ReadLine());
                        Rectangle rectangle = new Rectangle(x, y);
                        canvas1.addMenento(new Memento(rectangle.ToString()));
                        Console.WriteLine("Rectangle added to canvas");
                    }
                    else if(shapeType == 'C' || shapeType == 'c'){
                        //Circle
                        Console.WriteLine("Enter x coordinate");
                        int x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter y coordinate");
                        int y = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter radius");
                        int radius = int.Parse(Console.ReadLine());
                        Circle circle = new Circle(x, y, radius);

                        canvas1.addMenento(new Memento(circle.ToString()));
                        Console.WriteLine("Circle added to canvas");
                    }
                    else if(shapeType == 'L' || shapeType == 'l'){
                        //Line
                        Console.WriteLine("Enter x1 coordinate");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter y1 coordinate");
                        int y1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter x2 coordinate");
                        int x2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter y2 coordinate");
                        int y2 = int.Parse(Console.ReadLine());
                        Line line = new Line(x1, y1, x2, y2);
                         canvas1.addMenento(new Memento(line.ToString()));
                        Console.WriteLine("Line added to canvas");
                    }
                    else{
                        Console.WriteLine("Invalid shape type");
                    }

                }
                else if(command == 'U' || command == 'u'){
                    //undo last operation
                    canvas1.removeMenento();
                    Console.WriteLine("Undo last operation");
                }
                else if(command == 'D' || command == 'd'){
                       //Display Canvas
                    Console.WriteLine("Display Canvas");
                    for (int i = 0; i < canvas1.getUndoStates().Count; i++)
                    {
                        Console.WriteLine(canvas1.getUndoStates()[i].getData());
                    }
                }
                
                else if(command == 'R' || command == 'r'){
                    //Redo last operation
                    canvas1.redo();
                    Console.WriteLine("Redo last operation");
                }
                else if(command == 'C' || command == 'c'){
                    //Clear canvas
                    canvas1.clearCanvas();
                }
                else if(command == 'S' || command == 's'){
                    //Save canvas
                    Console.WriteLine("Save canvas");
                    string svg = svgOpen;
                    for (int i = 1; i < canvas1.getUndoStates().Count; i++)
                    {
                        svg += canvas1.getUndoStates()[i].getData();
                    }
                    svg += svgClose;
                    Console.WriteLine(svg);
                    File.WriteAllText("canvas.svg", svg);
                }
                else if(command == 'Q' || command == 'q'){
                    //Quit application
                    break;
                    Console.WriteLine("Quit application");
                }
                else{
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
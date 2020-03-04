using BPMN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.bpmn
{
    public class SampleEditor
    {
        public static bool Create(string fileName)
        {
            Editor editor = new Editor();
            editor.Create("BPMN Model", "User");

            string id1 = editor.AddEvent(null, null, "Start Event", EventType.Start, EventTrigger.None, EventRole.None);
            string id2 = editor.AddActivity(null, "Task 1", ActivityType.Task, ActivityMarker.None, TaskType.User, null);
            string id3 = editor.AddActivity(null, "Task 2", ActivityType.Task, ActivityMarker.None, TaskType.Manual, null);
            string id4 = editor.AddActivity(null, "Task 3", ActivityType.Task, ActivityMarker.None, TaskType.Service, null);
            string id5 = editor.AddEvent(null, null, "End Event", EventType.End, EventTrigger.None, EventRole.None);
            string id7 = editor.AddFlow(null, null, id1, id2, null, FlowType.Sequence, null, false, FlowDirection.None);
            string id8 = editor.AddFlow(null, null, id2, id3, null, FlowType.Sequence, null, false, FlowDirection.None);
            string id9 = editor.AddFlow(null, null, id3, id4, null, FlowType.Sequence, null, false, FlowDirection.None);
            string id10 = editor.AddFlow(null, null, id4, id5, null, FlowType.Sequence, null, false, FlowDirection.None);

            string id = editor.AddDiagram("Test 1", 96);

            Shape shape = new Shape();
            Rectangle rect = new Rectangle(10, 10, 30, 30);
            shape.Bounds = new List<Rectangle>();
            shape.Bounds.Add(rect);
            shape.ElementRef = id1;
            editor.AddShape(id, shape);

            rect.Width = 70;
            rect.Offset(60, 0);
            shape.Bounds[0] = rect;
            shape.ElementRef = id2;
            editor.AddShape(id, shape);

            rect.Offset(100, 0);
            shape.Bounds[0] = rect;
            shape.ElementRef = id3;
            editor.AddShape(id, shape);

            rect.Offset(100, 0);
            shape.Bounds[0] = rect;
            shape.ElementRef = id4;
            editor.AddShape(id, shape);

            rect.Width = 30;
            rect.Offset(100, 0);
            shape.Bounds[0] = rect;
            shape.ElementRef = id5;
            editor.AddShape(id, shape);

            List<Point> points = new List<Point>();
            points.Add(new Point()); points.Add(new Point());
            points[0] = new Point(40, 25); points[1] = new Point(70, 25);
            Edge edge = new Edge() { ElementRef = id7, Points = points };
            editor.AddEdge(id, edge);

            points[0] = new Point(140, 25); points[1] = new Point(170, 25);
            edge = new Edge() { ElementRef = id8, Points = points };
            editor.AddEdge(id, edge);

            points[0] = new Point(240, 25); points[1] = new Point(270, 25);
            edge = new Edge() { ElementRef = id9, Points = points };
            editor.AddEdge(id, edge);

            points[0] = new Point(340, 25); points[1] = new Point(370, 25);
            edge = new Edge() { ElementRef = id10, Points = points };
            editor.AddEdge(id, edge);

            return editor.Save(fileName);
        }
    }
}

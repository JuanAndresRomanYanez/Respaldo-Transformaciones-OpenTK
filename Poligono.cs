using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Proyecto1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01
{
    public class Poligono
    {
        public List<Punto> puntos { get; set; }
        public Color4 color { get; set; }
        Punto p { get; set; }
        public Matrix4 m { get; set; }
        public Punto origin { get; set; }
        public Poligono()
        {
            puntos = new List<Punto>();
            this.color = color;
            m = Matrix4.Identity;
            origin = GetCentro();
        }
        public Poligono(Color4 color)
        {
            puntos = new List<Punto>();
            this.color = color;
            m = Matrix4.Identity;
            origin = GetCentro();
        }
        public Poligono(Color4 color, float x, float y, float z){
            puntos = new List<Punto>();
            this.color = color;
            this.p = new Punto(x, y, z);
            m = Matrix4.Identity;
            origin = GetCentro();
        }
        public Poligono(Poligono p, Color4 color)
        {
            puntos = new List<Punto>();
            this.color = color;
            m = Matrix4.Identity;
            origin = GetCentro();
            for (int i = 0; i < p.puntos.Count(); i++)
            {
                puntos.Add(new Punto(p.puntos[i]));
            }
        }
        
        public void Dibujar()
        {
            PrimitiveType primitiveType = PrimitiveType.Polygon;
            GL.Begin(primitiveType);
            GL.Color4(color);

            for (int i = 0; puntos.Count > i; i++)
            {
                GL.Vertex4(puntos.ElementAt(i).ToVector4() * m);
            }

            GL.End();

        }
        /*
        public void Dibujar(){

            PrimitiveType primitiveType = PrimitiveType.Polygon;
            GL.Begin(primitiveType);
            GL.Color4(color);

            for (int i = 0; puntos.Count > i; i++)
            {
                GL.Vertex3(puntos.ElementAt(i).ToVector3());
            }

            GL.End();

        }
        */
        public void Adicionar(float x, float y, float z)
        {
            puntos.Add(new Punto(x + p.x, y + p.y, z + p.z));
        }

        public void Adicionar(Punto punto)
        {
            puntos.Add(punto);
        }
        public void Eliminar(int i)
        {
            puntos.RemoveAt(i);
        }
        public void mover(Punto p)
        {
            foreach (Punto pun in puntos)
            {
                pun.acumular(p);
            }
        }
        public void Escalar(float scale)
        {
            m *= Matrix4.CreateScale(scale, scale, scale);
        }
        public void Rotar(float angle, char c)
        {
            switch (c)
            {
                case 'x':
                    m *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angle));
                    break;
                case 'y':
                    m *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angle));
                    break;
                case 'z':
                    m *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angle));
                    break;
                default: break;
            }
        }
        public void Trasladar(float x, float y, float z)
        {
            m *= Matrix4.CreateTranslation(x, y, z);//la matriz 
        }
        /*

        public void Escalar(float scale)
        {
            Matrix4 m = Matrix4.CreateScale(scale, scale, scale);
            Vector4 v = new Vector4();
            for (int i = 0; i < puntos.Count; i++)
            {
                v = puntos.ElementAt(i).ToVector4() * m;
                puntos.ElementAt<Punto>(i).setPunto(v.X, v.Y, v.Z);
            }
        }
        */
        /*
        public void Rotar(float angle, char c )
        {
            Matrix4 m = new Matrix4();
            switch (c)
            {
                case 'x': 
                    m = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angle));
                    break;
                case 'y':
                    m = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(angle));
                    break;
                case 'z':
                    m = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angle));
                    break;
                default: break;
            }
            Vector4 v = new Vector4();
            for (int i = 0; i < puntos.Count; i++)
            {
                v = puntos.ElementAt(i).ToVector4() * m;
                puntos.ElementAt<Punto>(i).setPunto(v.X, v.Y, v.Z);
            }
        }
        */
        /*
        public void Trasladar(float x, float y, float z)
        {
            Matrix4 m = Matrix4.CreateTranslation(x, y, z);//la matriz 
            Vector4 v = new Vector4();
            for (int i = 0; i < puntos.Count; i++)
            {
                v = puntos.ElementAt(i).ToVector4() * m;
                puntos.ElementAt<Punto>(i).setPunto(v.X, v.Y, v.Z);
            }
        }
        */
        public Punto GetCentro()
        {
            int numPuntos = puntos.Count;
            Punto origen = new Punto(0, 0, 0);
            foreach (Punto pun in puntos)
            {
                origen.x += pun.x;
                origen.y += pun.y;
                origen.z += pun.z;
            }
            origen.x /= numPuntos;
            origen.y /= numPuntos;
            origen.z /= numPuntos;

            return origen;
        }
        
    }
    
}

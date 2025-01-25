namespace Dices
{
    public class Dice
    {
        private List<int> faces;
        public Dice(){
            this.faces = new List<int>();
        }
        public Dice(List<int> faces){
            this.faces = faces;
        }
        public List<int> GetDice(){
            return faces;
        }
        public void SetDice(int face)
        {
            faces.Add(face);
        }
        public int Roll(int index){
            return faces[index];
        }
        public string DisplayDice() {
            int i = 0;
            string r = "";
            r += "[";
            foreach (var face in faces)
            {
                r += face;
                if(i < faces.Count - 1){
                    r += ", ";
                }
                i++;
            }
            r += "]";
            return r;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Events.Eventful.v1
{
    /// <summary>
    /// There is a bug in the way in which the server returns performers
    /// We have to hack around it..
    /// </summary>
    public class Performers
    {
        public string Name
        {
            get
            {
                if (performers == null) return performer.ToString();
                var name = "";
                foreach (var p in this.performers)
                {
                    name += p.name + ",";
                }
                return name;
            }
        }
        public List<Performer> performers
        {
            get
            {
                if (performer == null) return null;
                List<Performer> ps = new List<Performer>();
                var ary = (performer as System.Array);
                if (ary == null)
                {
                    var str = performer.ToString();
                    try
                    {
                        using (var reader = new StringReader(str))
                        {
                            var ser = new Newtonsoft.Json.JsonSerializer();
                            var p = (ser.Deserialize((reader as TextReader), typeof(Performer)) as Performer);
                            ps.Add(p);
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            using (var reader = new StringReader(str))
                            {
                                var ser = new Newtonsoft.Json.JsonSerializer();
                                var p = (ser.Deserialize((reader as TextReader), typeof(List<Performer>)) as List<Performer>);
                                ps.AddRange(p);
                            }

                        }
                        catch (Exception)
                        {
                        }
                    }

                }
                else
                {
                    foreach (var item in ary)
                    {
                        ps.Add(item as Performer);
                    }
                }
                return ps;
            }
        }
        public object performer { get; set; }
    }
}

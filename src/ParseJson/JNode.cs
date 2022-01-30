using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseJson
{
    public class JNode: JItem, IEnumerable<JItem>
    {
        private Dictionary<string, JItem> items = new Dictionary<string, JItem>();

        public JItem this[string key]
        {
            get => items[key];
            set => items[key] = value;
        }

        public bool ContainsKey(string key) => items.ContainsKey(key);

        public IEnumerator<JItem> GetEnumerator() => items.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => items.Values.GetEnumerator();

        public JNode Add(string name, JItem value)
        {
            items.Add(name, value);
            return this;
        }
    }
}

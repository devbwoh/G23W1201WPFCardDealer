using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace G23W1201WPFCardDealer; 

class CardModel {
    // propfull 입력 후 Tab 두 번
    private int[] _cards = new int[5] { -1, -1, -1, -1, -1 };

    public int[] Cards {
        get => _cards;
    }

    public void Shuffle() {
        Random r = new Random();
        int[] num = new int[5] { -1, -1, -1, -1, -1 };

        for (int i = 0; i < num.Length; i++) {
            int n = 0;
            do {
                n = r.Next(52);
            } while (num.Contains(n));
            num[i] = n;
        }

        Array.Sort(num);

        _cards = num;
    }
}

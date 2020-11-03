using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ModelProj;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gridbinding
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<PP> PPs = new List<PP>();

        private ObservableCollection<PP> _opps;
        public ObservableCollection<PP> Opps { get => _opps; set => Set(() => Opps, ref _opps, value); }
        private string _txt; public string Txt { get => _txt; set => Set(() => Txt, ref _txt, value); }


        private RelayCommand _dumpCmd;
        public RelayCommand DumpCmd => _dumpCmd ?? (_dumpCmd = new RelayCommand(
            () => dump(),
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));
        private void dump()
        {
            Txt = string.Empty;
            foreach (PP pp in Opps)
            {
                Txt += pp.ToString() + "\n";
            }
        }


        public MainWindowViewModel()
        {
            populate();
        }

        private void populate()
        {
            for (int i = 1; i <= 10; i++)
            {
                PPs.Add(new PP($"Name{i}", $"Desc{i}", i));
            }
            Opps = new ObservableCollection<PP>(PPs);
        }
    }
}

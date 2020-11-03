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



        private RelayCommand _replaceCmd;
        public RelayCommand ReplaceCmd => _replaceCmd ?? (_replaceCmd = new RelayCommand(
            () => replace(),
            () => { return 1 == 1; },
			keepTargetAlive:true
            ));
        private void replace()
        {
            List<PP> newList = new List<PP>();
            for (int i = 1; i <= 10; i++)
            {
                newList.Add(new PP($"N{i}", $"D{i}", i*10));
            }
            Opps = new ObservableCollection<PP>(newList);


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

﻿using RetroFun.Controls;
using RetroFun.Subscribers;
using Sulakore.Communication;
using Sulakore.Components;
using Sulakore.Habbo;
using Sulakore.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace RetroFun.Pages
{
    [ToolboxItem(true)]
    [DesignerCategory("UserControl")]
    public partial class MiscellaneousPage : ObservablePage, ISubscriber
    {
        private Random Randomizer = new Random();

        //private string OldLook = "";

        private int RoomID = 0;
        private string OwnerName = "NOT INITIATED";
        private string roomname = "NOT INITIATED";
        private bool newroom = true;


        #region Vars

        private bool SignCountEnabled;
        private bool DecreasingMode;
        private bool IncreasingMode = true;
        private bool GestureLoopEnabled;
        private bool SitModeEnabled;
        private bool DanceLoopEnabled;
        private bool TrollLookMode;
        private int LocalIndex;

        private readonly string TrollLook1 = "hr-155-42.ea-1333-33.ha-3786-62.ch-201410-89.sh-3333-3333.ca-3333-33-33.lg-44689-82.wa-3333-333.hd-209-1";
        private readonly string TrollLook2 = "hr-893-42.ea-1333-33.ha-3786-62.sh-6298462-82.wa-3333-333.ca-3333-33-33.lg-5772038-82-62.ch-987462876-89.hd-209-1";
        private readonly string TrollLook3 = "hr-893-42.cc-156282-77.ea-1333-33.ha-3786-62.ch-9784419-82.sh-3035-82.ca-3333-33-33.lg-6050208-78.wa-3333-333.hd-209-1";
        private Dictionary<int, HEntity> users = new Dictionary<int, HEntity>();


        private string OriginalLook = " ";

        #region DanceBools

        private bool _Dance_NoneSelected;

        public bool Dance_NoneSelected
        {
            get => _Dance_NoneSelected;
            set
            {
                _Dance_NoneSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _Dance_NormalSelected;

        public bool Dance_NormalSelected
        {
            get => _Dance_NormalSelected;
            set
            {
                _Dance_NormalSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _Dance_PogoMogoSelected;

        public bool Dance_PogoMogoSelected
        {
            get => _Dance_PogoMogoSelected;
            set
            {
                _Dance_PogoMogoSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _Dance_DuckFunkSelected;

        public bool Dance_DuckFunkSelected
        {
            get => _Dance_DuckFunkSelected;
            set
            {
                _Dance_DuckFunkSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _Dance_TheRollieSelected;

        public bool Dance_TheRollieSelected
        {
            get => _Dance_TheRollieSelected;
            set
            {
                _Dance_TheRollieSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private int _Dance_Cooldown = 500;

        public int Dance_Cooldown
        {
            get => _Dance_Cooldown;
            set
            {
                _Dance_Cooldown = value;
                RaiseOnPropertyChanged();
            }
        }

        #endregion DanceBools

        #region GesturesBools

        private bool _PogoHopSelected;

        public bool PogoHopSelected
        {
            get => _PogoHopSelected;
            set
            {
                _PogoHopSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _NoneGestureSelected;

        public bool NoneGestureSelected
        {
            get => _NoneGestureSelected;
            set
            {
                _NoneGestureSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ThumbsUpSelected;

        public bool ThumbsUpSelected
        {
            get => _ThumbsUpSelected;
            set
            {
                _ThumbsUpSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _WaveSelected;

        public bool WaveSelected
        {
            get => _WaveSelected;
            set
            {
                _WaveSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _SleepSelected;

        public bool SleepSelected
        {
            get => _SleepSelected;
            set
            {
                _SleepSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _LaughSelected;

        public bool LaughSelected
        {
            get => _LaughSelected;
            set
            {
                _LaughSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _KissSelected;

        public bool KissSelected
        {
            get => _KissSelected;
            set
            {
                _KissSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        #endregion GesturesBools


        #region SignBools

        private bool _YellowcardSelected;

        public bool YellowcardSelected
        {
            get => _YellowcardSelected;
            set
            {
                _YellowcardSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _RedcardSelected;

        public bool RedcardSelected
        {
            get => _RedcardSelected;
            set
            {
                _RedcardSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _SmileySelected;

        public bool SmileySelected
        {
            get => _SmileySelected;
            set
            {
                _SmileySelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _SoccerballSelected;

        public bool SoccerballSelected
        {
            get => _SoccerballSelected;
            set
            {
                _SoccerballSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ExclamationSelected;

        public bool ExclamationSelected
        {
            get => _ExclamationSelected;
            set
            {
                _ExclamationSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _SkullSelected;

        public bool SkullSelected
        {
            get => _SkullSelected;
            set
            {
                _SkullSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _HeartSelected;

        public bool HeartSelected
        {
            get => _HeartSelected;
            set
            {
                _HeartSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _InvisibleSignSelected;

        public bool InvisibleSignSelected
        {
            get => _InvisibleSignSelected;
            set
            {
                _InvisibleSignSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ConvertMessageForYouToFile;

        public bool ConvertMessageForYouToFile
        {
            get => _ConvertMessageForYouToFile;
            set
            {
                _ConvertMessageForYouToFile = value;
                RaiseOnPropertyChanged();
            }
        }


        private bool _ZeroSelected;

        public bool ZeroSelected
        {
            get => _ZeroSelected;
            set
            {
                _ZeroSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _OneSelected;

        public bool OneSelected
        {
            get => _OneSelected;
            set
            {
                _OneSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _TwoSelected;

        public bool TwoSelected
        {
            get => _TwoSelected;
            set
            {
                _TwoSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ThreeSelected;

        public bool ThreeSelected
        {
            get => _ThreeSelected;
            set
            {
                _ThreeSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _FourSelected;

        public bool FourSelected
        {
            get => _FourSelected;
            set
            {
                _FourSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _FiveSelected;

        public bool FiveSelected
        {
            get => _FiveSelected;
            set
            {
                _FiveSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _SixSelected;

        public bool SixSelected
        {
            get => _SixSelected;
            set
            {
                _SixSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _SevenSelected;

        public bool SevenSelected
        {
            get => _SevenSelected;
            set
            {
                _SevenSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _EightSelected;

        public bool EightSelected
        {
            get => _EightSelected;
            set
            {
                _EightSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _NineSelected;

        public bool NineSelected
        {
            get => _NineSelected;
            set
            {
                _NineSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _TenSelected;

        public bool TenSelected
        {
            get => _TenSelected;
            set
            {
                _TenSelected = value;
                RaiseOnPropertyChanged();
            }
        }

        private int _SignCounterCoolDown;

        public int SignCounterCoolDown
        {
            get => _SignCounterCoolDown;
            set
            {
                _SignCounterCoolDown = value;
                RaiseOnPropertyChanged();
            }
        }

        private int _ActionsCooldown = 250;

        public int GestureCooldown
        {
            get => _ActionsCooldown;
            set
            {
                _ActionsCooldown = value;
                RaiseOnPropertyChanged();
            }
        }

        private int _SitsCooldown = 250;

        public int SitsCooldown
        {
            get => _SitsCooldown;
            set
            {
                _SitsCooldown = value;
                RaiseOnPropertyChanged();
            }
        }

        #endregion SignBools

        #region miscvars

        private string _UsernameFilter;

        public string UsernameFilter
        {
            get => _UsernameFilter;
            set
            {
                _UsernameFilter = value;
                RaiseOnPropertyChanged();
            }
        }


        private bool _ConvertMessageForYou;

        public bool ConvertMessageForYou
        {
            get => _ConvertMessageForYou;
            set
            {
                _ConvertMessageForYou = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _BlockMessageForYou;


        public bool BlockMessageForYou
        {
            get => _BlockMessageForYou;
            set
            {
                _BlockMessageForYou = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _BlockStaffAlerts;


        public bool BlockStaffAlerts
        {
            get => _BlockStaffAlerts;
            set
            {
                _BlockStaffAlerts = value;
                RaiseOnPropertyChanged();
            }
        }


        private bool _AntiFriendRemove = true;

        public bool AntiFriendRemove
        {
            get => _AntiFriendRemove;
            set
            {
                _AntiFriendRemove = value;
                RaiseOnPropertyChanged();
            }
        }

        private int _TrollLookCooldown = 500;

        public int TrollLookCooldown
        {
            get => _TrollLookCooldown;
            set
            {
                _TrollLookCooldown = value;
                RaiseOnPropertyChanged();
            }
        }

        #endregion miscvars

        #endregion SignCountBools

        public MiscellaneousPage()
        {
            InitializeComponent();

            Bind(NoRemoveFriendOnReport, "Checked", nameof(AntiFriendRemove));
            Bind(ZeroChbx, "Checked", nameof(ZeroSelected));
            Bind(OneChbx, "Checked", nameof(OneSelected));
            Bind(TwoChbx, "Checked", nameof(TwoSelected));
            Bind(ThreeChbx, "Checked", nameof(ThreeSelected));
            Bind(FourChbx, "Checked", nameof(FourSelected));
            Bind(FiveChbx, "Checked", nameof(FiveSelected));
            Bind(SixChbx, "Checked", nameof(SixSelected));
            Bind(SevenChbx, "Checked", nameof(SevenSelected));
            Bind(EightChbx, "Checked", nameof(EightSelected));
            Bind(NineChbx, "Checked", nameof(NineSelected));
            Bind(TenChBx, "Checked", nameof(TenSelected));

            Bind(HearthChbx, "Checked", nameof(HeartSelected));
            Bind(SkullChbx, "Checked", nameof(SkullSelected));
            Bind(ExclamationChbx, "Checked", nameof(ExclamationSelected));
            Bind(SoccerBallChbx, "Checked", nameof(SoccerballSelected));
            Bind(SmilingFaceChbx, "Checked", nameof(SmileySelected));
            Bind(RedCardChbx, "Checked", nameof(RedcardSelected));
            Bind(YellowCardChbx, "Checked", nameof(YellowcardSelected));

            Bind(InvisibleSignChbx, "Checked", nameof(InvisibleSignSelected));

            Bind(Gesture_ThumbsUpChbx, "Checked", nameof(ThumbsUpSelected));
            Bind(Gesture_WaveChbx, "Checked", nameof(WaveSelected));
            Bind(Gesture_sleepChbx, "Checked", nameof(SleepSelected));
            Bind(Gesture_laughChbx, "Checked", nameof(LaughSelected));
            Bind(Gesture_KissChbx, "Checked", nameof(KissSelected));
            Bind(Gesture_NoneChbx, "Checked", nameof(NoneGestureSelected));
            Bind(Gesture_PogoHopChbx, "Checked", nameof(PogoHopSelected));

            Bind(Dance_NoneChbx, "Checked", nameof(Dance_NoneSelected));
            Bind(Dance_NormalChbx, "Checked", nameof(Dance_NormalSelected));
            Bind(Dance_PogoMogoChbx, "Checked", nameof(Dance_PogoMogoSelected));
            Bind(Dance_DuckFunkChbx, "Checked", nameof(Dance_DuckFunkSelected));
            Bind(Dance_TheRollieChbx, "Checked", nameof(Dance_TheRollieSelected));
            Bind(DancesCooldownNBx, "Value", nameof(Dance_Cooldown));

            Bind(SignCountCoolDown, "Value", nameof(SignCounterCoolDown));
            Bind(GestureCooldownNbx, "Value", nameof(GestureCooldown));
            Bind(SitCoolDownNbx, "Value", nameof(SitsCooldown));
            Bind(TrollLookNbx, "Value", nameof(TrollLookCooldown));


            Bind(ConvertMessageForYouChbx, "Checked", nameof(ConvertMessageForYou));
            Bind(BlockMessageForYouChbx, "Checked", nameof(BlockMessageForYou));
            Bind(BlockStaffAlertsChbx, "Checked", nameof(BlockStaffAlerts));
            Bind(ConvertMessageForyouFileChbx, "Checked", nameof(ConvertMessageForYouToFile));


            if (Program.Master != null)
            {
                Triggers.InAttach(In.MessagesForYou, HandleMessageForYou);
                Triggers.InAttach(In.RoomData, HandleRoomData);
            }

        }

        private void SignCountBtn_Click(object sender, EventArgs e)
        {
            SignCountCheck();
        }

        private void SignCountCheck()
        {
            if (SignCountEnabled)
            {
                SignCountEnabled = false;
                WriteToButton(SignCountBtn, "Sign Count : Off");
            }
            else
            {
                SignCountEnabled = true;
                WriteToButton(SignCountBtn, "Sign Count : On");
                SignCountThread();
            }
        }

        private void GestureOnLoopBtn_Click(object sender, EventArgs e)
        {
            GestureLoopManager();
        }

        private void GestureLoopManager()
        {
            if (GestureLoopEnabled)
            {
                GestureLoopEnabled = false;
                WriteToButton(GestureOnLoopBtn, "Gesture Loop : Off");
            }
            else
            {
                WriteToButton(GestureOnLoopBtn, "Gesture Loop : On");
                GestureLoopEnabled = true;
                GestureLoop();
            }
        }

        private void SitLoop()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                do
                {
                    Connection.SendToServerAsync(Out.RoomUserSit);
                    Thread.Sleep(SitsCooldown);
                } while (SitModeEnabled);
            }).Start();
        }

        private void GestureLoop()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                do
                {
                    if (GestureLoopEnabled)
                    {
                        if (ThumbsUpSelected)
                        {
                            SendGesturePacket(HGesture.ThumbsUp);
                            Thread.Sleep(GestureCooldown);
                        }
                        if (WaveSelected)
                        {
                            SendGesturePacket(HGesture.Wave);
                            Thread.Sleep(GestureCooldown);
                        }
                        if (SleepSelected)
                        {
                            SendGesturePacket(HGesture.Idle);
                            Thread.Sleep(GestureCooldown);
                        }
                        if (LaughSelected)
                        {
                            SendGesturePacket(HGesture.Laugh);
                            Thread.Sleep(GestureCooldown);
                        }
                        if (KissSelected)
                        {
                            SendGesturePacket(HGesture.BlowKiss);
                            Thread.Sleep(GestureCooldown);
                        }
                        if (PogoHopSelected)
                        {
                            SendGesturePacket(HGesture.PogoHop);
                            Thread.Sleep(GestureCooldown);
                        }
                        if (NoneGestureSelected)
                        {
                            SendGesturePacket(HGesture.None);
                            Thread.Sleep(GestureCooldown);
                        }
                    }
                } while (GestureLoopEnabled);
            }).Start();
        }

        public void InUserProfile(DataInterceptedEventArgs e)
        {
        }

        private void SendGesturePacket(HGesture Gesture)
        {
            if (Connection.Remote.IsConnected)
            {
                Connection.SendToServerAsync(Out.RoomUserAction, Gesture);
            }
        }

        private void SendDancePacket(HDance Dance)
        {
            if (Connection.Remote.IsConnected)
            {
                Connection.SendToServerAsync(Out.RoomUserDance, Dance);
            }
        }

        private void SignCountThread()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                do
                {
                    if (IncreasingMode)
                    {
                        if (!DecreasingMode)
                        {
                            if (ZeroSelected)
                            {
                                SendRoomSign(HSign.Zero);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (OneSelected)
                            {
                                SendRoomSign(HSign.One);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (TwoSelected)
                            {
                                SendRoomSign(HSign.Two);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (ThreeSelected)
                            {
                                SendRoomSign(HSign.Three);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (FourSelected)
                            {
                                SendRoomSign(HSign.Four);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (FiveSelected)
                            {
                                SendRoomSign(HSign.Five);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SixSelected)
                            {
                                SendRoomSign(HSign.Six);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SevenSelected)
                            {
                                SendRoomSign(HSign.Seven);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (EightSelected)
                            {
                                SendRoomSign(HSign.Eight);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (NineSelected)
                            {
                                SendRoomSign(HSign.Nine);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (TenSelected)
                            {
                                SendRoomSign(HSign.Ten);
                                Thread.Sleep(SignCounterCoolDown);
                            }

                            if (InvisibleSignSelected)
                            {
                                SendRoomSign(HSign.Invisible);
                                Thread.Sleep(SignCounterCoolDown);
                            }

                            if (HeartSelected)
                            {
                                SendRoomSign(HSign.Heart);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SkullSelected)
                            {
                                SendRoomSign(HSign.Skull);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (ExclamationSelected)
                            {
                                SendRoomSign(HSign.Exclamation);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SoccerballSelected)
                            {
                                SendRoomSign(HSign.Soccerball);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SmileySelected)
                            {
                                SendRoomSign(HSign.Smiley);
                                Thread.Sleep(SignCounterCoolDown);
                            }

                            if (RedcardSelected)
                            {
                                SendRoomSign(HSign.Redcard);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (YellowcardSelected)
                            {
                                SendRoomSign(HSign.Yellowcard);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                        }
                    }

                    if (DecreasingMode)
                    {
                        if (!IncreasingMode)
                        {
                            if (YellowcardSelected)
                            {
                                SendRoomSign(HSign.Yellowcard);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (RedcardSelected)
                            {
                                SendRoomSign(HSign.Redcard);
                                Thread.Sleep(SignCounterCoolDown);
                            }

                            if (SmileySelected)
                            {
                                SendRoomSign(HSign.Smiley);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SoccerballSelected)
                            {
                                SendRoomSign(HSign.Soccerball);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (ExclamationSelected)
                            {
                                SendRoomSign(HSign.Exclamation);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SkullSelected)
                            {
                                SendRoomSign(HSign.Skull);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (HeartSelected)
                            {
                                SendRoomSign(HSign.Heart);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (InvisibleSignSelected)
                            {
                                SendRoomSign(HSign.Invisible);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (TenSelected)
                            {
                                SendRoomSign(HSign.Ten);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (NineSelected)
                            {
                                SendRoomSign(HSign.Nine);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (EightSelected)
                            {
                                SendRoomSign(HSign.Eight);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SevenSelected)
                            {
                                SendRoomSign(HSign.Seven);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (SixSelected)
                            {
                                SendRoomSign(HSign.Six);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (FiveSelected)
                            {
                                SendRoomSign(HSign.Five);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (FourSelected)
                            {
                                SendRoomSign(HSign.Four);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (ThreeSelected)
                            {
                                SendRoomSign(HSign.Three);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (TwoSelected)
                            {
                                SendRoomSign(HSign.Two);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (OneSelected)
                            {
                                SendRoomSign(HSign.One);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                            if (ZeroSelected)
                            {
                                SendRoomSign(HSign.Zero);
                                Thread.Sleep(SignCounterCoolDown);
                            }
                        }
                    }
                } while (SignCountEnabled);
            }).Start();
        }

        private void SendRoomSign(HSign Sign)
        {
                Connection.SendToServerAsync(Out.RoomUserSign, Sign);
        }

        public bool IsReceiving => true;

        public void OnLatencyTest(DataInterceptedEventArgs obj)
        {
            if (UsernameFilter == null)
            {
                Connection.SendToServerAsync(Out.RequestUserData);
            }
        }

        public void OnUsername(DataInterceptedEventArgs obj)
        {
            string username = obj.Packet.ReadString();
            
            if (UsernameFilter == null)
            {
                UsernameFilter = username;
            }
        }

        public void OnRequestRoomLoad(DataInterceptedEventArgs e)
        {
            users.Clear();
            newroom = true;
        }


        public void InRoomUserLeft(DataInterceptedEventArgs e)
        {
            int index = int.Parse(e.Packet.ReadString());
            var UserLeaveEntity = users.Values.FirstOrDefault(ent => ent.Index == index);
            if (UserLeaveEntity == null) return;

            users.Remove(UserLeaveEntity.Id);
        }

        public void InUserEnterRoom(DataInterceptedEventArgs obj)
        {
            try
            {
                HEntity[] array = HEntity.Parse(obj.Packet);
                if (array.Length != 0)
                {
                    foreach (HEntity hentity in array)
                    {
                        if (!users.ContainsKey(hentity.Id))
                        {
                            users.Add(hentity.Id, hentity);
                        }
                        if (hentity.Name == UsernameFilter)
                        {
                            OriginalLook = hentity.FigureId;
                            LocalIndex = hentity.Index;
                        }
                    }
                }

            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        public void InPurchaseOk(DataInterceptedEventArgs e)
        {
        }


        public void OnOutUserRequestBadge(DataInterceptedEventArgs e)
        {
        }

        public void OnOutDiceTrigger(DataInterceptedEventArgs e)
        {
        }

        public void OnCatalogBuyItem(DataInterceptedEventArgs e)
        {
        }

        public void OnRoomUserWalk(DataInterceptedEventArgs e)
        {
        }
        public void OnUserFriendRemoval(DataInterceptedEventArgs e)
        {
            if (AntiFriendRemove)
                e.IsBlocked = true;
        }

        private void WriteToButton(SKoreButton button, string text)
        {
            Invoke((MethodInvoker)delegate
            {
                button.Text = text;
            });
        }

        private void CountingBtn_Click(object sender, EventArgs e)
        {
            ChangeCounting();
        }

        private void ChangeCounting()
        {
            if (IncreasingMode)
            {
                IncreasingMode = false;
                DecreasingMode = true;
                WriteToButton(CountingBtn, "10→0");
            }
            else if (DecreasingMode)
            {
                IncreasingMode = true;
                DecreasingMode = false;
                WriteToButton(CountingBtn, "0→10");
            }
        }

        private void UserSitBtn_Click(object sender, EventArgs e)
        {
            Connection.SendToServerAsync(Out.RoomUserSit);
        }

        private void SitCheck()
        {
            if (SitModeEnabled)
            {
                SitModeEnabled = false;
                WriteToButton(SitOnLoopBtn, "Sit Loop : Off");
            }
            else
            {
                SitModeEnabled = true;
                WriteToButton(SitOnLoopBtn, "Sit Loop : On");
                SitLoop();
            }
        }

        private void SitOnLoopBtn_Click(object sender, EventArgs e)
        {
            SitCheck();
        }

        //public string GenInt()
        //{
        //    int Random = Randomizer.Next(0, 9);

        //    //if(!(OldRandom == Random))
        //    //{
        //    //    OldRandom = Random;
        //    return Random.ToString();
        //    //}
        //    //return GenInt();
        //}

        //private void GenerateMaleLook()
        //{
        //    string Look = "ca-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".ch-" + GenInt() + GenInt() + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".lg-" + GenInt() + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".sh-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + GenInt() + GenInt() + ".wa-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + GenInt() + ".hd-" + GenInt() + GenInt() + GenInt() + "-" + GenInt() + ".hr-" + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".ha-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".ea-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + "";
        //    if (Look != OldLook)
        //    {
        //        OldLook = Look;
        //        Console.WriteLine("USer Look set to : " + Look);
        //        if (Connection.Remote.IsConnected)
        //        {
        //            Connection.SendToServerAsync(Out.UserSaveLook, "M", Look);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Found Duplicated look!");
        //        GenerateMaleLook();
        //    }
        //}

        //private void GenerateFemaleLook()
        //{
        //    if (Connection.Remote.IsConnected)
        //    {
        //        Connection.SendToServerAsync(Out.UserSaveLook, "F", "ca-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".ch-" + GenInt() + GenInt() + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".lg-" + GenInt() + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".sh-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + GenInt() + GenInt() + ".wa-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + GenInt() + ".hd-" + GenInt() + GenInt() + GenInt() + "-" + GenInt() + ".hr-" + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".ha-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + ".ea-" + GenInt() + GenInt() + GenInt() + GenInt() + "-" + GenInt() + GenInt() + "");
        //    }
        //}

        ////private void GenLookGenThreadBtn_Click(object sender, EventArgs e)
        ////{
        ////}

        ////private void ToggleLookGen()
        ////{
        ////}






        private void DanceLoopBtn_Click(object sender, EventArgs e)
        {
            if (DanceLoopEnabled)
            {
                DanceLoopEnabled = false;
                WriteToButton(DanceLoopBtn, "Dance Loop : Off");
            }
            else
            {
                DanceLoopEnabled = true;
                WriteToButton(DanceLoopBtn, "Dance Loop : On");
                DanceLoop();
            }
        }


        private void DanceLoop()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                do
                {
                    if (DanceLoopEnabled)
                    {
                        if (Dance_NoneSelected)
                        {
                            SendDancePacket(HDance.None);
                            Thread.Sleep(Dance_Cooldown);
                        }
                        if (Dance_NormalSelected)
                        {
                            SendDancePacket(HDance.Normal);
                            Thread.Sleep(Dance_Cooldown);
                        }
                        if (Dance_PogoMogoSelected)
                        {
                            SendDancePacket(HDance.PogoMogo);
                            Thread.Sleep(Dance_Cooldown);
                        }
                        if (Dance_DuckFunkSelected)
                        {
                            SendDancePacket(HDance.DuckFunk);
                            Thread.Sleep(Dance_Cooldown);
                        }
                        if (Dance_TheRollieSelected)
                        {
                            SendDancePacket(HDance.TheRollie);
                            Thread.Sleep(Dance_Cooldown);
                        }
                    }
                } while (DanceLoopEnabled);
                if (!DanceLoopEnabled)
                {
                    SendDancePacket(HDance.None);
                }
            }).Start();
        }

        private void SendLookPacket(string look)
        {
            if (Connection.Remote.IsConnected)
            {
                Connection.SendToServerAsync(Out.UserSaveLook, "M", look);
            }
        }

        private void EffectLoopBtn_Click(object sender, EventArgs e)
        {
        }

        private void TrollLookBtn_Click(object sender, EventArgs e)
        {
            CheckLookTroll();
        }

        private void CheckLookTroll()
        {
            if (TrollLookMode)
            {
                TrollLookMode = false;
                WriteToButton(TrollLookBtn, "Troll look : off");
            }
            else
            {
                TrollLookMode = true;
                WriteToButton(TrollLookBtn, "Troll look : On");
                TrollLookLoop();
            }
        }

        
        private string StripUnicode(string name)
        {
            string process1 = Regex.Replace(name, @"\p{C}+", String.Empty);
            return  new string(process1.Where(c => char.IsLetter(c) || char.IsDigit(c) || char.IsSymbol(c)).ToArray());
        }

        private void HandleRoomData(DataInterceptedEventArgs e)
        {
            e.Packet.ReadBoolean();
            RoomID = e.Packet.ReadInteger();
            roomname = e.Packet.ReadString();
            OwnerName = StripUnicode(e.Packet.ReadString());
            e.Packet.ReadInteger();
            e.Packet.ReadInteger();
            e.Packet.ReadInteger();
            e.Packet.ReadInteger();
            e.Packet.ReadInteger();
            e.Packet.ReadInteger();
        }

        private void HandleMessageForYou(DataInterceptedEventArgs e)
        {
            e.Packet.ReadInteger();
            string message = e.Packet.ReadString();
            if(BlockMessageForYou)
            {
                e.IsBlocked = true;
            }
            if(ConvertMessageForYou)
            {
                Speak(message);
                e.IsBlocked = true;
            }
            if(ConvertMessageForYouToFile)
            {
                StoreToInput(message);
                e.IsBlocked = true;
            }

        }


        private void Speak(string text)
        {
            if (Connection.Remote.IsConnected)
            {
                Connection.SendToClientAsync(In.RoomUserWhisper, 0, "[MessageForYou]: " + text, 0, 34, 0, -1);
            }
        }



        private void TrollLookLoop()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                do
                {
                    if (TrollLookMode)
                    {
                        SendLookPacket(TrollLook1);
                        Thread.Sleep(TrollLookCooldown);
                        SendLookPacket(TrollLook2);
                        Thread.Sleep(TrollLookCooldown);
                        SendLookPacket(TrollLook3);
                        Thread.Sleep(TrollLookCooldown);
                    }
                } while (TrollLookMode);
                if (!TrollLookMode)
                {
                    SendLookPacket(OriginalLook);
                }
            }).Start();
        }

        private void StartPollBtn_Click(object sender, EventArgs e)
        {
            StartCSPoll();
        }

        private void StartCSPoll()
        {
            Connection.SendToClientAsync(In.SimplePollStart, "MATCHING_POLL", 2505, 8451, 15000, 8451, 3, 6, "RetroFun : Select your Answer to show SS", 0, 6, 0, 0);
        }



        public void InItemExtraData(DataInterceptedEventArgs e)
        {
        }
        public void OnRoomUserTalk(DataInterceptedEventArgs e)
        {

        }

        public void OnRoomUserStartTyping(DataInterceptedEventArgs e)
        {
        }

        public void InFloorItemUpdate(DataInterceptedEventArgs e)
        {
        }
        public void OnRoomUserShout(DataInterceptedEventArgs e)
        {

        }

        public void OnRoomUserWhisper(DataInterceptedEventArgs e)
        {

        }

        public void InRoomUserTalk(DataInterceptedEventArgs e)
        {
            int index = e.Packet.ReadInteger();
            string text = e.Packet.ReadString();
            SaveChatlog(text, "TALKING", FindUsername(index));
        }

        public void InRoomUserShout(DataInterceptedEventArgs e)
        {
            int index = e.Packet.ReadInteger();
            string text = e.Packet.ReadString();
            SaveChatlog(text, "SHOUTING", FindUsername(index));
        }


        public void InRoomUserWhisper(DataInterceptedEventArgs e)
        {
            int index = e.Packet.ReadInteger();
            string text = e.Packet.ReadString();
            SaveChatlog(text, "WHISPERING", FindUsername(index));
        }

        private void SendFriendRequest(string username)
        {
            Connection.SendToServerAsync(Out.FriendRequest, username);
        }

        private void AddYourselfAsFriendBtn_Click(object sender, EventArgs e)
        {
            if(UsernameFilter != null)
            {
                SendFriendRequest(UsernameFilter);
            }
        }

        private string FindUsername(int index)
        {
            try
            {
                if (users != null)
                {
                    return users.Values.FirstOrDefault(e => e.Index == index).Name;
                }
                else
                {
                    return "NULL";
                }
            } 
            catch(NullReferenceException)
            {
                return "NULL";
            }
        }
        

        private void StoreToInput(string text)
        {
            try
            {
                string Filepath = "../RetroFunLogs/" + "MessageForYouToText" + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".log";

                string FolderName = "RetroFunLogs";

                Directory.CreateDirectory("../" + FolderName);

                if (!File.Exists(Filepath))
                {
                    using (var txtFile = File.AppendText(Filepath))
                    {
                        txtFile.WriteLine("RetroFun MessageForYou Output Generated in " + DateTime.Now.ToString());
                        txtFile.WriteLine("");
                        txtFile.WriteLine("----------------------------------------------------");
                        txtFile.WriteLine(text);
                        txtFile.WriteLine("----------------------------------------------------");
                    }
                }
                else if (File.Exists(Filepath))
                {
                    using (var txtFile = File.AppendText(Filepath))
                    {
                        txtFile.WriteLine("RetroFun MessageForYou Output Generated in " + DateTime.Now.ToString());
                        txtFile.WriteLine("");
                        txtFile.WriteLine("----------------------------------------------------");
                        txtFile.WriteLine(text);
                        txtFile.WriteLine("----------------------------------------------------");
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {

            }
        }

        private string GetHost(string host)
        {
            if (host == "217.182.58.18")
            {
                return "bobbaitalia.it";
            }
            else
            {
                return host;
            }
        }

        private void SaveChatlog(string text, string TalkType, string entityname)
        {
            try
            {
                if (entityname != "NULL")
                {
                    string Filepath = "../RetroFunLogs/" + GetHost(Connection.Host) + "_Chatlog" + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".log";
                    string FolderName = "RetroFunLogs";

                    Directory.CreateDirectory("../" + FolderName);

                    if (!File.Exists(Filepath))
                    {
                        using (var txtFile = File.AppendText(Filepath))
                        {
                            txtFile.WriteLine("RetroFun Chatlog stored at :" + DateTime.Now.ToString());
                            if (newroom)
                            {
                                txtFile.WriteLine("");
                                txtFile.WriteLine("Room : " + RoomID + " Room Owner : " + OwnerName + " Room Name : " + roomname);
                                txtFile.WriteLine("----------------------------------------------------");
                                newroom = false;
                            }
                            txtFile.WriteLine("[" + DateTime.Now + "]" + "[CHATLOG] : " + "[" + TalkType + "]" + " " + entityname + ": " + text);
                        }
                    }
                    else if (File.Exists(Filepath))
                    {
                        using (var txtFile = File.AppendText(Filepath))
                        {
                            if (newroom)
                            {
                                txtFile.WriteLine("");
                                txtFile.WriteLine("Room : " + RoomID + " Room Owner : " + OwnerName + " Room Name : " + roomname);
                                txtFile.WriteLine("----------------------------------------------------");
                                newroom = false;
                            }
                            else
                            {
                                txtFile.WriteLine("[" + DateTime.Now + "]" + "[CHATLOG] : " + "[" + TalkType + "]" + " " + entityname + ": " + text);
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {

            }
        }

    }
}
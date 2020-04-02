﻿using RetroFun.Controls;
using RetroFun.Helpers;
using RetroFun.Properties;
using RetroFun.Subscribers;
using Sulakore.Communication;
using Sulakore.Components;
using Sulakore.Habbo;
using Sulakore.Modules;
using Sulakore.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace RetroFun.Pages
{
    [ToolboxItem(true)]
    [DesignerCategory("UserControl")]
    public partial class ChatPage : ObservablePage, ISubscriber
    {
        private HMessage replacement;
        private HMessage FlooderMessages;
        private int LocalIndex;

        private bool isRaidMode;

        private int[] rainbowlist = new int[] { 3, 4, 5, 6, 7, 11, 12, 13, 14, 15, 18 };

        //private int oldrainbowbubble;
        //private int newrainbowselected;

        private Random rand = new Random();

        public bool IsReceiving => true;

        private bool BlockRoomLoad;

        private bool _FlooderEnabled;

        private int FloodServerBubble;

        public bool FlooderEnabled
        {
            get => _FlooderEnabled;
            set
            {
                _FlooderEnabled = value;
                RaiseOnPropertyChanged();
            }
        }



        private string _FlooderText;

        public string FlooderText
        {
            get => _FlooderText;
            set
            {
                _FlooderText = value;
                RaiseOnPropertyChanged();
            }
        }


        private int _FlooderCooldown = 50 ;

        public int FlooderCooldown
        {
            get => _FlooderCooldown;
            set
            {
                _FlooderCooldown = value;
                RaiseOnPropertyChanged();
            }
        }


        private bool _antiBobbaFilter;

        public bool AntiBobbaFilter
        {
            get => _antiBobbaFilter;
            set
            {
                _antiBobbaFilter = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _useSelectedBubble;

        public bool UseSelectedBubbleServerSide
        {
            get => _useSelectedBubble;
            set
            {
                _useSelectedBubble = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _UseSelectedBubbleClientSide;

        public bool UseSelectedBubbleClientSide
        {
            get => _UseSelectedBubbleClientSide;
            set
            {
                _UseSelectedBubbleClientSide = value;
                RaiseOnPropertyChanged();
            }
        }


        private bool _hideSpeakingBubble;

        public bool HideSpeakingBubble
        {
            get => _hideSpeakingBubble;
            set
            {
                _hideSpeakingBubble = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ForceChatSpeak;

        public bool ForceChatSpeak
        {
            get => _ForceChatSpeak;
            set
            {
                _ForceChatSpeak = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ForceNormalSpeak = true;

        public bool ForceNormalSpeak
        {
            get => _ForceNormalSpeak;
            set
            {
                _ForceNormalSpeak = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ForceShoutChat;

        public bool ForceShoutChat
        {
            get => _ForceShoutChat;
            set
            {
                _ForceShoutChat = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _ForceWhisperChat;

        public bool ForceWhisperChat
        {
            get => _ForceWhisperChat;
            set
            {
                _ForceWhisperChat = value;
                RaiseOnPropertyChanged();
            }
        }

        private bool _RainbowChatEnabled;

        public bool RainbowChatEnabled
        {
            get => _RainbowChatEnabled;
            set
            {
                _RainbowChatEnabled = value;
                RaiseOnPropertyChanged();
            }
        }

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


        private string _CloneUsernameFilter;

        public string CloneUsernameFilter
        {
            get => _CloneUsernameFilter;
            set
            {
                _CloneUsernameFilter = value;
                RaiseOnPropertyChanged();
            }
        }

        private int _MainUserIndex;

        public int MainUserIndex
        {
            get => _MainUserIndex;
            set
            {
                _MainUserIndex = value;
                RaiseOnPropertyChanged();
            }
        }


        public int SelectedSSBubbleId { get; private set; }
        public int SelectedCSBubbleId { get; private set; }

        public ChatPage()
        {
            InitializeComponent();

            Bind(AntiBobbaFilterChbx, "Checked", nameof(AntiBobbaFilter));
            Bind(UseSelectedBubbleSSChbx, "Checked", nameof(UseSelectedBubbleServerSide));
            Bind(UseSelectedBubbleCSChbx, "Checked", nameof(UseSelectedBubbleClientSide));

            Bind(UsernameTextBox, "Text", nameof(UsernameFilter));

            Bind(HideSpeakingBubbleChbx, "Checked", nameof(HideSpeakingBubble));
            Bind(ForceDefSpeakBox, "Checked", nameof(ForceChatSpeak));
            Bind(NormalTalkBox, "Checked", nameof(ForceNormalSpeak));
            Bind(ShoutTalkBox, "Checked", nameof(ForceShoutChat));
            Bind(WhisperChatBox, "Checked", nameof(ForceWhisperChat));
            Bind(RainbowChatChbx, "Checked", nameof(RainbowChatEnabled));

            Bind(TextFloodPhraseBox, "Text", nameof(FlooderText));
            Bind(CooldownFloodNbx, "Value", nameof(FlooderCooldown));
            Bind(TargetUserTxb, "Text", nameof(CloneUsernameFilter));
            Bind(IndexNbx, "Value", nameof(MainUserIndex));


            var imageType = typeof(Image);

            ResourceSet res = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            IOrderedEnumerable<DictionaryEntry> reorder = res.Cast<DictionaryEntry>().OrderBy(i => int.Parse(i.Key.ToString().Substring(1)));

            foreach (DictionaryEntry entry in reorder)
            {
                string name = entry.Key.ToString();

                if (string.IsNullOrWhiteSpace(name) || name[0] != '_') continue;

                name = name.Substring(1);
                int bubbleId = int.Parse(name);

                if (entry.Value.GetType() != imageType && !entry.Value.GetType().IsSubclassOf(imageType)) continue;
                BubblesSSCmbx.AddImageItem((Image)entry.Value, name, bubbleId);
                BubblesCSCmbx.AddImageItem((Image)entry.Value, name, bubbleId);

            }

            BubblesSSCmbx.SelectedIndex = 17;
            BubblesCSCmbx.SelectedIndex = 17;
            if (Program.Master != null)
            {
                Triggers.OutAttach(Out.RoomUserStartTyping, RoomUserStartTyping);
            }

        }


        public void OnLatencyTest(DataInterceptedEventArgs obj)
        {
            if (UsernameFilter == null)
            {
                Connection.SendToServerAsync(Out.RequestUserData);
                BlockRoomLoad = true;
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


        private void WriteToButton(SKoreButton Button, string text)
        {
            Invoke((MethodInvoker)delegate
            {
                Button.Text = text;
            });
            

        }
        private void ForceDefSpeakBox_CheckedChanged(object sender, EventArgs e)
        {
            ToggleChatDefault();
        }

        private void RainbowChatChbx_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRainbowChatRequirements();
        }

        private int GetRainbowBubbleint()
        {
            return rainbowlist[rand.Next(rainbowlist.Length)];
        }


        private void ToggleRainbowChatRequirements()
        {
            if (RainbowChatEnabled)
            {
                ToggleComboBox(BubblesSSCmbx, true);
                ToggleCheckbox(UseSelectedBubbleSSChbx, true);
            }
            else
            {
                ToggleComboBox(BubblesSSCmbx, false);
                ToggleCheckbox(UseSelectedBubbleSSChbx, false);
            }
        }


        private void ToggleChatDefault()
        {
            if (ForceChatSpeak)
            {
                ToggleGroupbox(GroupChatDefault, false);
            }
            else
            {
                ToggleGroupbox(GroupChatDefault, true);
            }
        }

        private void ToggleGroupbox(GroupBox Group, bool Actived)
        {
            Invoke((MethodInvoker)delegate
            {
                Group.Enabled = Actived;
            });
        }

        private void ToggleCheckbox(CheckBox checkbox, bool Actived)
        {
            Invoke((MethodInvoker)delegate
            {
                checkbox.Enabled = Actived;
            });
        }


        private void ToggleComboBox(ImageComboBox box, bool Actived)
        {
            Invoke((MethodInvoker)delegate
            {
                box.Enabled = Actived;
            });
        }

        public void InUserEnterRoom(DataInterceptedEventArgs obj)
        {
            try
            {
                if (UsernameFilter != null)
                {
                    HEntity[] array = HEntity.Parse(obj.Packet);
                    if (array.Length != 0)
                    {
                        foreach (HEntity hentity in array)
                        {
                            if (hentity.Name == UsernameFilter)
                            {
                                LocalIndex = hentity.Index;
                            }
                            if(hentity.Name == CloneUsernameFilter)
                            {
                                MainUserIndex = hentity.Index;
                            }
                        }
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
            }
        }


        public void InPurchaseOk(DataInterceptedEventArgs e)
        {
        }

        public void OnOutDiceTrigger(DataInterceptedEventArgs e)
        {
        }

        public void OnCatalogBuyItem(DataInterceptedEventArgs e)
        {
        }
        public void OnUserFriendRemoval(DataInterceptedEventArgs e)
        {
        }

        public void InUserProfile(DataInterceptedEventArgs e)
        {
        }

        public void OnRequestRoomLoad(DataInterceptedEventArgs e)
        {
            if (BlockRoomLoad)
            {

                e.IsBlocked = true;
                BlockRoomLoad = false;
            }

        }
        public void OnOutUserRequestBadge(DataInterceptedEventArgs e)
        {
        }

        public void InRoomUserLeft(DataInterceptedEventArgs e)
        {
        }

        public void OnRoomUserWalk(DataInterceptedEventArgs e)
        {
        }

        public void InItemExtraData(DataInterceptedEventArgs e)
        {
        }

        private void BubblesCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Avoid cross-thread exceptions by waiting for an event in the UI thread to update this property.
            SelectedSSBubbleId = (int)BubblesSSCmbx.SelectedTag;
        }

        private void BubblesCSCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Avoid cross-thread exceptions by waiting for an event in the UI thread to update this property.
            SelectedCSBubbleId = (int)BubblesCSCmbx.SelectedTag;
        }

        private void RoomUserStartTyping(DataInterceptedEventArgs obj)
        {
            obj.IsBlocked = HideSpeakingBubble;
        }









        public void OnRoomUserTalk(DataInterceptedEventArgs e)
        {
            RoomUserStartSpeaking(e);
        }

        public void OnRoomUserShout(DataInterceptedEventArgs e)
        {
            RoomUserStartSpeaking(e);
        }

        public void OnRoomUserWhisper(DataInterceptedEventArgs e)
        {
            RoomUserStartSpeaking(e);
        }


        public void InRoomUserTalk(DataInterceptedEventArgs e)
        {
            int index = e.Packet.ReadInteger();
            string msg = e.Packet.ReadString();
            e.Packet.ReadInteger();
            int bubbleid = e.Packet.ReadInteger();
            if (UseSelectedBubbleClientSide)
            {
                if (index == LocalIndex)
                {
                    e.IsBlocked = true;
                    Connection.SendToClientAsync(In.RoomUserTalk, LocalIndex, msg, 0, SelectedCSBubbleId, 0, -1);
                }
            }
            if (isRaidMode)
            {
                if (index == MainUserIndex)
                {
                    Connection.SendToServerAsync(Out.RoomUserTalk, " " + msg, bubbleid);
                }
            }
        }

        public void InRoomUserShout(DataInterceptedEventArgs e)
        {
            int index = e.Packet.ReadInteger();
            string msg = e.Packet.ReadString();
            e.Packet.ReadInteger();
            int bubbleid = e.Packet.ReadInteger();

            if (UseSelectedBubbleClientSide)
            {
                if (index == LocalIndex)
                {
                    e.IsBlocked = true;
                    Connection.SendToClientAsync(In.RoomUserShout, LocalIndex, msg, 0, SelectedCSBubbleId, 0, -1);
                }
            }

            if (isRaidMode)
            {
                if (index == MainUserIndex)
                {
                    Connection.SendToServerAsync(Out.RoomUserShout, " " + msg, bubbleid);
                }
            }
        }

        public void InRoomUserWhisper(DataInterceptedEventArgs e)
        {
            int index = e.Packet.ReadInteger();
            string msg = e.Packet.ReadString();
            e.Packet.ReadInteger();
            int bubbleid = e.Packet.ReadInteger();

            if (UseSelectedBubbleClientSide)
            {
                if (index == LocalIndex)
                {
                    e.IsBlocked = true;
                    Connection.SendToClientAsync(In.RoomUserWhisper, LocalIndex, msg, 0, SelectedCSBubbleId, 0, -1);
                }
            }
        }





        private void RoomUserStartSpeaking(DataInterceptedEventArgs Packet)
        {
            string message = Packet.Packet.ReadString();
            int bubbleId = Packet.Packet.ReadInteger();

            string whisperTarget = null;
            if (Packet.Packet.Header == Out.RoomUserWhisper)
            {
                whisperTarget = message.Split(' ')[0];
                message = message.Substring(whisperTarget.Length);
            }

            if (AntiBobbaFilter)
            {
                message = BypassFilter(message);
            }

            if (!string.IsNullOrWhiteSpace(whisperTarget))
            {
                message = whisperTarget + " " + message;
            }

            if (UseSelectedBubbleServerSide)
            {
                bubbleId = SelectedSSBubbleId;
            }

            if (RainbowChatEnabled)
            {
                int Debug = GetRainbowBubbleint();
                bubbleId = Debug;
            }

            Packet.IsBlocked = true;
            if (!ForceChatSpeak)
            {
                replacement = new HMessage(Packet.Packet.Header, message, bubbleId);
            }
            else
            {
                if (ForceNormalSpeak)
                {
                    replacement = new HMessage(Out.RoomUserTalk, " " + message, bubbleId);
                }
                else if (ForceShoutChat)
                {
                    replacement = new HMessage(Out.RoomUserShout, " " + message, bubbleId);
                }
                else if (ForceWhisperChat)
                {
                    replacement = new HMessage(Out.RoomUserWhisper, " " + message, bubbleId);
                }
            }


            if (Packet.Packet.Readable > 0)
            {
                replacement.WriteInteger(0);
            }
            if (Connection.Remote.IsConnected)
            {
                Connection.SendToServerAsync(replacement);
            }
        }

        private string BypassFilter(string message)
        {
            var builder = new StringBuilder(message.Length * 5);
            foreach (char character in message)
            {
                builder.Append("&#" + (int)character + "º;");
            }
            return builder.ToString();
        }


        private HMessage FloodMessageBuilder()
        {
            string FloodMessage;

                if (AntiBobbaFilter)
                {
                    FloodMessage = BypassFilter(FlooderText);
                }
                else
                {
                    FloodMessage = FlooderText;
                }

                if (UseSelectedBubbleServerSide)
                {
                    FloodServerBubble = SelectedSSBubbleId;
                }
                else
                {
                    FloodServerBubble = 18;
                }

                if (RainbowChatEnabled)
                {
                    int Debug = GetRainbowBubbleint();
                    FloodServerBubble = Debug;
                }
                if (!ForceChatSpeak)
                {
                FlooderMessages = new HMessage(Out.RoomUserTalk, FloodMessage, FloodServerBubble);
                }
                else
                {
                    if (ForceNormalSpeak)
                    {
                    FlooderMessages = new HMessage(Out.RoomUserTalk, FloodMessage, FloodServerBubble);
                    }
                    else if (ForceShoutChat)
                    {
                    FlooderMessages = new HMessage(Out.RoomUserShout, FloodMessage, FloodServerBubble);
                    }
                    else if (ForceWhisperChat)
                    {
                    FlooderMessages = new HMessage(Out.RoomUserWhisper, FloodMessage, FloodServerBubble);
                    }
                }
            
            return FlooderMessages;
        }

        private void StartFloodThread()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                do
                {
                    if(FlooderEnabled)
                    {

                        Thread.Sleep(FlooderCooldown);
                        Connection.SendToServerAsync(FloodMessageBuilder());
                        Thread.Sleep(100);

                    }

                } while (FlooderEnabled);
            }).Start();
        }




        private void FloodBtn_Click(object sender, EventArgs e)
        {
            if(FlooderEnabled)
            {
                WriteToButton(FloodBtn, "Flooder : OFF");
                FlooderEnabled = false;
            }
        else
            {
                WriteToButton(FloodBtn, "Flooder : ON");
                FlooderEnabled = true;
                StartFloodThread();
            }
        }



        private void CloneUserSpeakBtn_Click(object sender, EventArgs e)
        {
            if(isRaidMode)
            {
                WriteToButton(CloneUserSpeakBtn, "Clone User Speak : OFF");
                isRaidMode = false;
            } else {

                WriteToButton(CloneUserSpeakBtn, "Clone User Speak : ON");
                isRaidMode = true;
                Connection.SendToClientAsync(In.RoomUserWhisper, 0, "Warning: This can result in a ban of the account! Use with caution!", 0, 34, 0, -1);

            }

        }
    }
}
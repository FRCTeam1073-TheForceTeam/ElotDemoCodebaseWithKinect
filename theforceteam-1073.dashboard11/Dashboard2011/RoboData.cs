using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dashboard2011
{
    class RoboData
    {
        public RoboData(byte[] packet)
        {
            if (packet == null) { return; }
            this.packet = packet;
            BoolifiedPackedInfo = new bool[System.Runtime.InteropServices.Marshal.SizeOf(PackedInfo) * 8];

            int index = 31;

            PacketID = GetUInt(ref index);
            TestBytes = GetUInt(ref index);
            PackedInfo = GetUShort(ref index);

            BoolifyPackedInfo();
            if (ConstantPacket)
            {
                XCameraAngle = GetFloat(ref index);
                YCameraAngle = GetFloat(ref index);
                // *****
            }
            else
            {
                for (int i = 0; i < analogs.Length; i++)
                {
                    analogs[i] = GetFloat(ref index);
                }
                frelays = GetByte(ref index);
                rrelays = GetByte(ref index);
                IO = GetUShort(ref index);
                IOdir = GetUShort(ref index);
                for (int i = 0; i < PWMs.Length; i++)
                {
                    PWMs[i] = GetByte(ref index);
                }
                TimeLeft = GetFloat(ref index);
                BatteryVoltage = GetFloat(ref index);
                Gyro = GetFloat(ref index);
                LjoyX = GetFloat(ref index);
                RjoyX = GetFloat(ref index);
                LjoyY = GetFloat(ref index);
                RjoyY = GetFloat(ref index);
                LEncoder = GetFloat(ref index);
                REncoder = GetFloat(ref index);
                X = GetFloat(ref index);
                Y = GetFloat(ref index);
                XAccel = GetFloat(ref index);
                YAccel = GetFloat(ref index);
                XVel = GetFloat(ref index);
                YVel = GetFloat(ref index);
                SX = GetFloat(ref index);
                SY = GetFloat(ref index);
                Heading = GetFloat(ref index);
                ElevatorHeight = GetFloat(ref index);
                DesiredElevatorHeight = GetFloat(ref index);
                LCurrent = GetFloat(ref index);
                RCurrent = GetFloat(ref index);
                PincherCurrent = GetFloat(ref index);
                ArmCurrent = GetFloat(ref index);
                ElevatorCurrent = GetFloat(ref index);
                PincherOpen = GetFloat(ref index);
                DelayMeasurer = GetInt(ref index);
                Time = GetFloat(ref index);
                SystemTime = GetFloat(ref index);
                xpeg = GetByte(ref index);
                ypeg = GetByte(ref index);
                PegAngle = GetFloat(ref index);
                BaitAngle = GetFloat(ref index);
                PegDist = GetFloat(ref index);
                BaitDist = GetFloat(ref index);
                PincherMag = GetFloat(ref index);
                ArmMag = GetFloat(ref index);

                DCBA25 = GetUInt(ref index);

                // ***** not sent yet
                DesiredSpeed = GetFloat(ref index);
                DesiredAngle = GetFloat(ref index);
                ArmHeight = GetFloat(ref index);
                DesiredArmHeight = GetFloat(ref index);
                ArmMotor = GetFloat(ref index);                
                ElevatorMotor = GetFloat(ref index);
                LencRaw = GetInt(ref index);
                RencRaw = GetInt(ref index);
                LMotor = GetFloat(ref index);
                RMotor = GetFloat(ref index);
            }
        }
        public byte[] packet;

        #region data
        public uint PacketID;
        public uint TestBytes;
        public ushort PackedInfo; // saves space with bit packing.  Change type in BoolifiedPackedInfo decl.
        #region variables
        public float[] analogs = new float[8];
        public byte frelays;
        public byte rrelays;
        public ushort IO;
        public ushort IOdir;
        public byte[] PWMs = new byte[10];
        public float TimeLeft;
        public float BatteryVoltage;
        public float Gyro;
        public float LjoyX;
        public float RjoyX;
        public float LjoyY;
        public float RjoyY;
        public float LEncoder;
        public float REncoder;
        public float XAccel;
        public float YAccel;
        public float XVel;
        public float YVel;
        public float X;
        public float Y;
        public float SX; // std. dev.
        public float SY;
        public float Heading;
        public float PincherOpen;
        public int LencRaw;
        public int RencRaw;
        public float LMotor;
        public float RMotor;
        public float Time;
        public float SystemTime;
        public float DesiredSpeed;
        public float DesiredAngle;
        public float ArmHeight;
        public float DesiredArmHeight;
        public float ArmMotor;
        public float ElevatorHeight;
        public float DesiredElevatorHeight;
        public float ElevatorMotor;
        public int DelayMeasurer;
        public byte xpeg;
        public byte ypeg;
        public float PegAngle;
        public float BaitAngle;
        public float PegDist;
        public float BaitDist;
        public float LCurrent;
        public float RCurrent;
        public float PincherCurrent;
        public float ArmCurrent;
        public float ElevatorCurrent;
        public float PincherMag;
        public float ArmMag;

        public uint DCBA25;
        #endregion
        #region constants
        public float XCameraAngle;
        public float YCameraAngle;
        #endregion
        #region variable accessors
        public bool GetDigIO(int port)
        {
            int pow = 1 << port;
            return (IO & pow) != 0;
        }
        public bool GetDigIOState(int port)
        {
            int pow = 1 << port;
            return (IOdir & pow) != 0;
        }

        public bool IsEnabled
        {
            get
            {
                return BoolifiedPackedInfo[1];
            }
        }
        public bool TubeDetected
        {
            get
            {
                return BoolifiedPackedInfo[2];
            }
        }
        public Mode Mode
        {
            get
            {
                bool tele = BoolifiedPackedInfo[3];
                bool auto = BoolifiedPackedInfo[4];
                if (tele && auto) { return Mode.Twilight; }
                else if (tele || auto) { return tele ? Mode.Teleoperated : Mode.Autonomous; }
                else return Mode.Other;
            }
        }
        public bool FollowingLine
        {
            get
            {
                return BoolifiedPackedInfo[5];
            }
        }
        public bool ArmUp { get { return BoolifiedPackedInfo[6]; } }
        public bool ArmDown { get { return BoolifiedPackedInfo[7]; } }
        public bool PincerClosed { get { return BoolifiedPackedInfo[8]; } }
        public bool PincerOpen { get { return BoolifiedPackedInfo[9]; } }
        public bool leftLineSensor { get { return BoolifiedPackedInfo[10]; } }
        public bool middleLineSensor { get { return BoolifiedPackedInfo[11]; } }
        public bool rightLineSensor { get { return BoolifiedPackedInfo[12]; } }
        #endregion
        #region constant accessors
        public Alliance Alliance
        {
            get
            {
                return BoolifiedPackedInfo[1] ? Alliance.Red : Alliance.Blue;
            }
        }
        public bool ConstantPacket
        {
            get { return !BoolifiedPackedInfo[0]; }
        }
        #endregion
        #endregion

        private bool[] BoolifiedPackedInfo = null;
        private void BoolifyPackedInfo()
        {
            var info = PackedInfo;
            for(int i = 0; i < BoolifiedPackedInfo.Length; i ++)
            {
                BoolifiedPackedInfo[i] = info%2 != 0;
                info /= 2;
            }
        }

        #region type-getters
        private short GetShort(ref int index)
        {
            int size = sizeof(short);
            
            // switch endianness
            for (int i = 0; i < size/2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToInt16(packet, index-size);
            
        }
        private int GetInt(ref int index)
        {
            int size = sizeof(int);

            // switch endianness
            for (int i = 0; i < size / 2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToInt32(packet, index-size);
            
        }
        private long GetLong(ref int index)
        {
            int size = sizeof(long);

            // switch endianness
            for (int i = 0; i < size / 2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToInt64(packet, index-size);
            
        }
        private ushort GetUShort(ref int index)
        {
            int size = sizeof(ushort);

            // switch endianness
            for (int i = 0; i < size / 2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToUInt16(packet, index-size);
            
        }
        private uint GetUInt(ref int index)
        {
            int size = sizeof(uint);

            // switch endianness
            for (int i = 0; i < size / 2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToUInt32(packet, index-size);
            
        }
        private ulong GetULong(ref int index)
        {
            int size = sizeof(ulong);

            // switch endianness
            for (int i = 0; i < size / 2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToUInt64(packet, index-size);
            
        }
        private float GetFloat(ref int index)
        {
            int size = sizeof(float);

            // switch endianness
            for (int i = 0; i < size / 2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToSingle(packet, index-size);
            
        }
        private double GetDouble(ref int index)
        {
            int size = sizeof(double);

            // switch endianness
            for (int i = 0; i < size / 2; i++)
            {
                byte temp = packet[index + i];
                packet[index + i] = packet[index + size - i - 1];
                packet[index + size - i - 1] = temp;
            }

            index += size;
            return BitConverter.ToDouble(packet, index - size);
            
        }
        private byte GetByte(ref int index)
        {
            index++;
            return packet[index - 1];
        }
        #endregion

        public override string ToString()
        {
            return this.ConstantPacket ? "Const" : "Vars";
        }
    }
    enum Mode
    {
        Twilight,
        Autonomous,
        Teleoperated,
        Other
    }
    enum Alliance
    {
        Red,
        Blue
    }
}

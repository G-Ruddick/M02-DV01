using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Chapter.Command {
    class Invoker : MonoBehaviour {
        private bool isRecording;
        private bool isReplaying;
        private float replayTime;
        private float recordTime;

        private SortedList<float, Command> recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command) {
            command.Execute();

            if (isRecording) {
                recordedCommands.Add(recordTime, command);
                
                Debug.Log("Recorded Time: " + recordTime);
                Debug.Log("Recorded Command: " + command);
            }
        }

        public void Record() {
            recordTime = 0;
            isRecording = true;
        }

        public void Replay() {
            replayTime = 0;
            isReplaying = true;

            if (recordedCommands.Count <= 0) {
                recordedCommands.Reverse();
            }
        }

        void FixedUpdate() {
            if (isRecording) {
                recordTime += Time.fixedDeltaTime;
            }
            if (isReplaying) {
                replayTime += Time.fixedDeltaTime;

                if (recordedCommands.Any()) {
                    if (Mathf.Approximately(replayTime, recordedCommands.Keys[0])) {
                        recordedCommands.Values[0].Execute();
                        recordedCommands.RemoveAt(0);
                    }
                }
                else {
                    isReplaying = false;
                }
            }
        }
    }
}
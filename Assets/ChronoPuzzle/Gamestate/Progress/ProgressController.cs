using System.Linq;
using ChronoPuzzle.Puzzles.Modern;
using ChronoPuzzle.World.Environment;
using ChronoPuzzle.World.Interactive;
using ChronoPuzzle.World.Player;
using ChronoPuzzle.World.Vision;
using Outfrost;
using UnityEngine;

namespace ChronoPuzzle.Gamestate.Progress {

    public class ProgressController : MonoBehaviour {
    
        private RoomManager roomManager;
        private GameObject playerCharacter;
        private Epoch currentEpoch = Epoch.Intro;
        private EpochChangeListenerScript[] listenerScripts;

        private void Start() {
            playerCharacter = GameObject.FindGameObjectWithTag("Player");
            if (playerCharacter == null) {
                Debug.LogError("No player object found in scene");
            }
            
            listenerScripts = Resources.FindObjectsOfTypeAll<EpochChangeListenerScript>()
                    .Where(obj => ! Util.IsPrefab(obj.gameObject))
                    .ToArray();
            
            broadcastEpochChange();
            print("Currently running epoch " + EpochUtil.epochName(currentEpoch));
            
            advanceIfPossible();
        }

        public void advanceIfPossible()
        {
            if (canAdvance() && FadeController.Instance.IsFinish) // TODO Ensure better concurrency safety for FadeController
            {
                print("Currently running epoch " + EpochUtil.epochName(currentEpoch) + ", advancing");
                playerCharacter.SetActive(false);
        
                FadeController.Instance.FadeOut(1.0f, Color.black, () =>
                {
                    currentEpoch = EpochUtil.next(currentEpoch);
                    broadcastEpochChange();
                    print("Currently running epoch " + EpochUtil.epochName(currentEpoch));
                    FadeController.Instance.FadeIn(1.0f, Color.black);
                });
            }
        }

        private void broadcastEpochChange() {
            foreach (var script in listenerScripts) {
                script.epochChanged(currentEpoch);
            }
        }

        private bool canAdvance() {
            switch (currentEpoch) {
                case Epoch.Intro: return isIntroEpochFinished();
                case Epoch.First: return isFirstEpochFinished();
                case Epoch.Second: return isSecondEpochFinished();
                default: return false;
            }
        }

        private bool isIntroEpochFinished() {
            return true;
        }

        private bool isFirstEpochFinished() {
            if (! GameObject.Find("rynna starozytnosc").GetComponent<RynnaScript>().isActive()) {
                return false;
            }
            
            GameObject.Find("Player Character").GetComponent<PlayerObjectInteractionScript>().heldObject.SetActive(false);
            GameObject.Find("Player Character").GetComponent<PlayerObjectInteractionScript>().heldObject = null;
            return true;

        }

        private bool isSecondEpochFinished() {
            return GameObject.Find("switches").GetComponent<LightBulbsPuzzle>().checkAllSocketsForWin();
        }

    }

}

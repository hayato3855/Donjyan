using UnityEngine;


namespace Donjyan
{
    public class PagerModel
    {
        public void ViewNextPage(GameObject[] items,ref int nowPage)
        {
            // 配列の番号は０スタートでページは１スタートだから−１して数を合わせる
            int page = nowPage -1;

            items[page].SetActive(false);
            items[nowPage++].SetActive(true);
        }

        public void ViewFrontPage(GameObject[] items,ref int nowPage)
        {
            items[--nowPage].SetActive(false);
            // 配列の番号は０スタートでページは１スタートだから−１して数を合わせる；
            int page = nowPage -1;
            items[page].SetActive(true);
        }

        public void CloseTutorial()
        {
            MatchState.s_HasTutorial = true;
        }
    }
}

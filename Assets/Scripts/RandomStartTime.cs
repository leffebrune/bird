/*
This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org/>

<author>Marc Vandenbosch</author>
<date>2015-08-08</date>
*/

using UnityEngine;
using System.Collections;

namespace JabberwockyStudio {
	
/*
<summary>
Starts the animation at random time
</summary>
*/
[RequireComponent(typeof (Animator))]
public class RandomStartTime : MonoBehaviour {
	/*
	<summary>
	Index of the layer of the default state
	</summary>
	*/
	[Tooltip("Index of the layer of the default state")]
	public int _layerIndex = 0;
	
	void OnEnable () {
		Animator anim = GetComponent<Animator>();
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(_layerIndex);
		anim.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
	}
}
}

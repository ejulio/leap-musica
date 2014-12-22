using Sanford.Multimedia.Midi;
using UnityEngine;
using System.Collections;

public class SanfordHelper : MonoBehaviour {

    static readonly OutputDevice device = new OutputDevice(0);

	public void Play(int note)
	{
		var message = new ChannelMessage(ChannelCommand.NoteOn, 0, note, 127);
		device.Send(message);
	}

	public void Stop(int note)
	{
		var message = new ChannelMessage(ChannelCommand.NoteOff, 0, note, 0);
		device.Send(message);
	}

}

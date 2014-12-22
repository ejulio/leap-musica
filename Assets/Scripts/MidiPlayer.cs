using Sanford.Multimedia;
using Sanford.Multimedia.Midi;

public class MidiPlayer
{
	OutputDevice device;

	public MidiPlayer ()
	{
		device = new OutputDevice(0);
	}

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
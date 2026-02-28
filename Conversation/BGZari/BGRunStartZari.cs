using FMOD;
using FSPRO;
using Nickel;
using System;
using System.Data;

namespace ZariMod.Conversation;

public class BGRunStartZari : BG
{


    private bool rumble;
    private double rumbleTimer;
    private double halfPoint;
    private double flashTimer;
    private double soundCooldown;






    public override void Render(G g, double t, Vec offset)
    {
        Color color = new Color(0.0, 0.1, 0.2).gain(0.5);
        Draw.Fill(color);
        BGComponents.NormalStars(g, t, offset);
        BGComponents.RegularNebula(g, offset, color);

        if (soundCooldown > 0)
        {
            soundCooldown -= g.dt;
        }
        if (rumble)
        {
            rumbleTimer -= g.dt;
            if (rumbleTimer <= 0)
            {
                rumbleTimer = 1.0 + Mutil.NextRand() * 3.0;
                halfPoint = rumbleTimer / 2;
                PlayerScreenDamage.OneShot();
                g.state.shake += 0.5;
                if (soundCooldown <= 0)
                {
                    ISoundInstance isi = ModEntry.Instance.ZariHullHit.CreateInstance();
                    isi.Volume = 0.25f;
                    isi.Pitch = (float)Mutil.Lerp(0.65, 1, rumbleTimer / 4);
                    soundCooldown = 0.8;
                }
            }
            Draw.Fill(new Color(1, 0.6, 0.4).gain(Math.Max(0, rumbleTimer - halfPoint) / 8.0), BlendMode.Screen);
        }
        if (flashTimer > 0.0)
        {
            //g.state.shake += flashTimer;
            Draw.Fill(new Color(1, 0.6, 0.4).gain(flashTimer / 3.0), BlendMode.Screen);
            Draw.Fill(new Color(1, 0.6, 0.4).fadeAlpha(flashTimer / 4.0));
            flashTimer -= g.dt;
        }

    }


    public override void OnAction(State s, string action)
    {
        switch (action)
        {
            case "rumble_on":
                rumble = true;
                break;
            case "flash_weak":
                flashTimer = 1;
                PlayerScreenDamage.OneShot();
                ISoundInstance isi = ModEntry.Instance.ZariHullHit.CreateInstance();
                isi.Volume = soundCooldown > 0 ? 0.3f : 0.7f;
                isi.Pitch = 1.2f;
                soundCooldown = 1;
                s.shake = 2;
                break;
            case "flash":
                flashTimer = 2;
                s.shake = 3;
                Audio.Play(new GUID?(Event.Hits_HitHurt), true);
                soundCooldown = 1;
                break;
            case "bonk":
                s.shake += 0.4;
                break;
        }
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

	public AudioSource[] soundEffects;

	public AudioSource bgm, levelEndMusic;

	Subscription<SimpleDivItemSelectionEvent> simple_div_item_selection_event;
	Subscription<DivinationEvent> divination_starts_event_subscription;
	Subscription<MiniGamePerfectEvent> mini_game_perfect_event_subscription;
	Subscription<MiniGameHitEvent> mini_game_hit_event_subscription;
	Subscription<MiniGameFailEvent> mini_game_fail_event_subscription;

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
    void Start()
    {
		simple_div_item_selection_event = EventBus.Subscribe<SimpleDivItemSelectionEvent>(PlaySelectionSFX);
		divination_starts_event_subscription = EventBus.Subscribe<DivinationEvent>(PlayDivinationSFX);
		mini_game_perfect_event_subscription = EventBus.Subscribe<MiniGamePerfectEvent>(PlayMiniGamePerfectSFX);
		mini_game_hit_event_subscription = EventBus.Subscribe<MiniGameHitEvent>(PlayMiniGameHitSFX);
		mini_game_fail_event_subscription = EventBus.Subscribe<MiniGameFailEvent>(PlayMiniGameFailSFX);
	}

    // Update is called once per frame
    void Update()
    {

    }

	public void PlaySFX(int soundToPlay)
	{
		// soundEffects[soundToPlay].Stop();
		soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
		soundEffects[soundToPlay].Play();
	}

	void PlaySelectionSFX(SimpleDivItemSelectionEvent e)
    {
		PlaySFX(1);
    }

	void PlayDivinationSFX(DivinationEvent e)
    {
		PlaySFX(2);
    }

	void PlayMiniGamePerfectSFX(MiniGamePerfectEvent e)
    {
		PlaySFX(3);
    }

	void PlayMiniGameHitSFX(MiniGameHitEvent e)
	{
		PlaySFX(4);
	}

	void PlayMiniGameFailSFX(MiniGameFailEvent e)
	{
		PlaySFX(5);
	}
}

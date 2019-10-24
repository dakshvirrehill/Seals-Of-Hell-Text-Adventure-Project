#pragma once
#ifndef ONE_INTERACTION_ITEM_H
#define ONE_INTERACTION_ITEM_H
#include "IInteractable.h"
#include "IUpdatable.h"
class OneInteractionItem : public IInteractable, public IUpdatable
{
	bool mIsMovable;
	bool mIsPlayable;
	bool mIsEatable;
	bool mIsRiddle;
public:
	OneInteractionItem() : IInteractable(), mIsMovable(false), mIsPlayable(false), mIsEatable(false), mIsRiddle(false)
	{ }
	void initialize(bool, bool, bool, bool);
	void lookObject() override;
	void moveObject() override;
	void playObject() override;
	void eatObject() override;
	void answerRiddle() override;
	void update() override;
	void endUpdate() override;
};
#endif
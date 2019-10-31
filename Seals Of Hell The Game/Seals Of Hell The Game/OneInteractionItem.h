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
	~OneInteractionItem() {}
	void initialize(bool, bool, bool, bool);
	void lookObject() override;
	void moveObject() override;
	void playObject() override;
	void eatObject() override;
	void answerRiddle() override;
	void onEnable() override;
	void update() override;
	void endUpdate() override;
	json::JSON getItemJSON() override;
	std::string getType() override { return "OneInteractionItem"; }
};
#endif
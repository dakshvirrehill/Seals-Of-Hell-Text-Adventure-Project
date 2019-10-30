#pragma once
#ifndef TREASURE_COLLECTOR_H
#define TREASURE_COLLECTOR_H
#include "IInteractable.h"
#include "IUpdatable.h"
#include <map>
#include <string>
class TreasureCollector : public IInteractable , public IUpdatable
{
	std::map<std::string,IInteractable*> mTreasures;
public:
	TreasureCollector() : IInteractable(),IUpdatable(),mTreasures() {}
	~TreasureCollector();
	void onEnable() override;
	void update() override;
	void endUpdate() override;
	void giveObject(IInteractable*) override;
	void addTreasures(IInteractable*);
};
#endif
#pragma once
#ifndef ANALYTICS_MANAGER_H
#define ANALYTICS_MANAGER_H
#include <string>
#include <map>
struct GameData
{
	int mGameID;
	double mGameTimeInSeconds;
	int mNumberofItemsInInventory;
};

struct ActionData
{
	int mActionId;
	std::string mCommandName;
	int mCount;
};

struct PickableData
{
	int mPickableId;
	std::string mPickableName;
	int mType;
	int mPickCount;
	int mDropCount;
};

class AnalyticsManager
{
	inline explicit AnalyticsManager() : mGameData(nullptr),mActionData(),mPickableData() {}
	inline ~AnalyticsManager() {}
	inline explicit AnalyticsManager(AnalyticsManager const&) : mGameData(nullptr), mActionData(), mPickableData() {}
	inline AnalyticsManager& operator=(AnalyticsManager const&)
	{
		return *this;
	}
protected:
	GameData*  mGameData;
	std::map<std::string, ActionData*> mActionData;
	std::map<std::string, PickableData*> mPickableData;
	void ReInitializeAnalyticsData();
	void SaveAnalyticsData();
public:
	inline static AnalyticsManager& instance()
	{
		static AnalyticsManager mInstance;
		return mInstance;
	}
	void UpdateActionData(std::string pActionName);
	void SetGameData(GameData*);
	void UpdatePickableData(std::string pPickableName, bool pIsPicked);
	friend class DatabaseManager;
	friend class GameManager;
};
#endif
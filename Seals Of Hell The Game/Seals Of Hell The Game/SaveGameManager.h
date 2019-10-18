#pragma once
#ifndef SAVE_GAME_MANAGER_H
#define SAVE_GAME_MANAGER_H
#include<string>
namespace json { class JSON; }
class SaveGameManager
{
private:
	inline explicit SaveGameManager() {}
	inline ~SaveGameManager() {}
	inline explicit SaveGameManager(SaveGameManager const&) {}
	inline SaveGameManager& operator=(SaveGameManager const&)
	{
		return *this;
	}
public:
	inline static SaveGameManager& instance()
	{
		static SaveGameManager mInstance;
		return mInstance;
	}
	json::JSON& loadGame(std::string&);
	bool saveGame(json::JSON&,std::string&);
};
#endif

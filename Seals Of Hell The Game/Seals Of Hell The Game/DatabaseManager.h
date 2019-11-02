#pragma once
#ifndef DATABASE_MANAGER_H
#define DATABASE_MANAGER_H
class sqlite3;
/*
################
SQLITE Database select insert and update queries called from this class at start and end of game by the analytics manager only
################
*/
class DatabaseManager
{
	inline explicit DatabaseManager() {}
	inline ~DatabaseManager() {}
	inline explicit DatabaseManager(DatabaseManager const&) {}
	inline DatabaseManager& operator=(DatabaseManager const&)
	{
		return *this;
	}
protected:
	inline static DatabaseManager& instance() 
	{
		static DatabaseManager mInstance;
		return mInstance;
	}
	void getAllData();
	void setAllData();
	friend class AnalyticsManager;
};
#endif
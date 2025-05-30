"use client";

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Progress } from "@/components/ui/progress";
import { Flame, CheckCircle, Target } from "lucide-react";

type ChallengeStatsProps = {
  totalChallenges: number;
  completedChallenges: number;
  activeStreak: number;
};

export default function ChallengeStats({
  totalChallenges,
  completedChallenges,
  activeStreak,
}: ChallengeStatsProps) {
  const completionRate =
    totalChallenges > 0 ? (completedChallenges / totalChallenges) * 100 : 0;

  return (
    <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mt-6">
      {/* Total Challenges */}
      <Card className="hover:shadow-lg transition">
        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
          <CardTitle className="text-sm font-medium text-muted-foreground">Total Challenges</CardTitle>
          <Target className="h-5 w-5 text-gray-500" />
        </CardHeader>
        <CardContent>
          <div className="text-3xl font-bold">{totalChallenges}</div>
          <p className="text-xs text-gray-500 mt-1">Challenges you’ve created or joined</p>
        </CardContent>
      </Card>

      {/* Completed Challenges */}
      <Card className="hover:shadow-lg transition">
        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
          <CardTitle className="text-sm font-medium text-muted-foreground">Completed</CardTitle>
          <CheckCircle className="h-5 w-5 text-green-500" />
        </CardHeader>
        <CardContent>
          <div className="text-3xl font-bold">{completedChallenges}</div>
          <Progress value={completionRate} className="mt-3" />
          <p className="text-xs text-gray-500 mt-2">
            {completionRate.toFixed(0)}% completion rate
          </p>
        </CardContent>
      </Card>

      {/* Streak */}
      <Card className="hover:shadow-lg transition">
        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
          <CardTitle className="text-sm font-medium text-muted-foreground">Current Streak</CardTitle>
          <Flame className="h-5 w-5 text-orange-500" />
        </CardHeader>
        <CardContent>
          <div className="text-3xl font-bold">{activeStreak} days</div>
          <p className="text-xs text-gray-500 mt-1">🔥 Keep it up!</p>
        </CardContent>
      </Card>
    </div>
  );
}

"use client";

import ChallengeStats from "@/components/ChallengeStats";
import Header from "@/components/Header";

export default function Home() {
  return (
    <>
      <Header />

      <ChallengeStats
      totalChallenges={15}
      completedChallenges={9}
      activeStreak={5}
      />

    </>
  );
}

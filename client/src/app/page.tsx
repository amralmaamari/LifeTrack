"use client";

import React, { useEffect, useState } from "react";
import axios from "axios";
import { AlarmClock, Bell, CheckCircle } from "lucide-react";
import ChallengeStats from "@/components/ChallengeStats";
import Header from "@/components/Header";
import Loading from "@/components/Loading"; // Optional custom loading component

export default function Home() {
  const [challengesToday, setChallengesToday] = useState<number>(0);
  const [alertsToday, setAlertsToday] = useState<number>(0);
  const [focusSessionsToday, setFocusSessionsToday] = useState<number>(0); // if needed
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const apiUrl = process.env.NEXT_PUBLIC_API_URL;
  const userId = 1; // 👈 Replace with dynamic user ID if needed

  useEffect(() => {
    const fetchStats = async () => {
      try {
        const [challengeRes, alertRes] = await Promise.all([
          axios.get(`${apiUrl}/Challenge/user/${userId}/today-count`),
          axios.get(`${apiUrl}/Alert/user/${userId}/today-count`)
        ]);

        

        setChallengesToday(challengeRes.data.data);
        setAlertsToday(alertRes.data.data);

        // You can add a third one for focus sessions if you have it
        // setFocusSessionsToday(...);

      } catch (err) {
        setError("⚠️ فشل تحميل الإحصائيات. حاول مرة أخرى لاحقًا.");
      } finally {
        setLoading(false);
      }
    };

    fetchStats();
  }, [apiUrl, userId]);



  return (
    <>
      <Header />
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mt-6">
        <ChallengeStats
          title="كل التحديات "
          total={challengesToday}
          icon={<CheckCircle className="h-5 w-5 text-green-600" />}
          description="عدد التحديات التي تم انشاءة"
        />

        <ChallengeStats
          title="تنبيهات اليوم الغير مكتملة" 
          total={alertsToday}
          icon={<Bell className="h-5 w-5 text-blue-500" />}
          description="عدد التنبيهات التي تم إنشاؤها اليوم"
        />

        {/* <ChallengeStats
          title="جلسات تركيز"
          total={focusSessionsToday}
          icon={<AlarmClock className="h-5 w-5 text-indigo-500" />}
          description="عدد الجلسات المركزة (غير مفعل بعد)"
        /> */}
      </div>
    </>
  );
}



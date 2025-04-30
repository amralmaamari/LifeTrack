"use client";

import Header from "@/components/Header";
import { useAuth } from "@/context/auth-context";
import Link from "next/link";

export default function Home() {
  const { user, logout, isLoggedIn } = useAuth();

  return (
    <>
      <Header />

      <main className="p-6 max-w-3xl mx-auto">
        {isLoggedIn ? (
          <div>
            <h1 className="text-2xl font-bold mb-4">Welcome back, {user?.fullName} 👋</h1>
            <p className="text-gray-700 mb-4">You’re logged in with {user?.email}</p>
            <button
              onClick={logout}
              className="text-white bg-red-500 hover:bg-red-600 px-4 py-2 rounded"
            >
              Logout
            </button>
          </div>
        ) : (
          <div>
            <h1 className="text-2xl font-bold mb-4">Welcome to LifeTrack 👋</h1>
            <p className="text-gray-600 mb-4">Please login or create an account to get started.</p>
            <div className="flex gap-4">
              <Link href="/login">
                <span className="text-blue-600 hover:underline">Login</span>
              </Link>
              <Link href="/signup">
                <span className="text-blue-600 hover:underline">Register</span>
              </Link>
            </div>
          </div>
        )}
      </main>
    </>
  );
}

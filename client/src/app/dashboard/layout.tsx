import { AppSidebar } from "@/components/app-sidebar";
import { SidebarProvider, SidebarTrigger } from "@/components/ui/sidebar";


export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  
  return (
    <>
      <SidebarProvider>
        <AppSidebar />
        <main className="pl-3 pr-4 w-full">
          {" "}
          {/* Adjust padding/margins as needed */}
          <SidebarTrigger />
          {children}
        </main>
      </SidebarProvider>
    </>
  );
}

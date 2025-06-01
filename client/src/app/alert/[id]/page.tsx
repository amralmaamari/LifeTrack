'use client'

import Loading from '@/components/Loading';
import TaskAlertCompletion from '@/components/TaskAlertCompletion';
import useFetch from '@/hooks/useFetch';
import { useParams } from 'next/navigation';
import React from 'react';

export interface IAlertDetails {
  alertId: number;
  taskId: number;
  measurementId: number;
  scoreMeasurement: string;
  notice: string;
  dateAndTime: string; // ISO format, يمكن تحويله إلى Date عند الحاجة
  isCompleted: boolean;
  title: string;
  description: string;
}

export default function Page() {
  const { id } = useParams();
  const { data, error, loading } = useFetch({ url: `/Alert/${id}/details` });


const task = data as IAlertDetails;

 console.log("from task: " + JSON.stringify(task, null, 2));
if(error) {
  console.error("Error fetching alert details:", error);
  

  if (loading || !data) {
    return <Loading message="جاري تحميل المنبّه..." />;
  }

  return (
    <div className="p-4">
       <TaskAlertCompletion
        taskID={task.taskId}
        alertID={task.alertId}
        isCompleted={task.isCompleted}
        title={task.title}
        description={task.description}
        note={task.notice}
        scoreMeasurement={task.scoreMeasurement}
        measurementId={task.measurementId}
      /> 
      
    </div>
  );
}

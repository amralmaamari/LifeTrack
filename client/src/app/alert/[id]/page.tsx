'use client'

import Loading from '@/components/Loading';
import TaskAlertCompletion from '@/components/TaskAlertCompletion';
import useFetch from '@/hooks/useFetch';
import { useParams } from 'next/navigation';
import { useRouter } from 'next/router';
import React from 'react';

export default function Page() {
  const { id } = useParams();
  const { data, error, loading } = useFetch({ url: `/Alert/${id}` });

  console.log(data);
  



  if (loading || !data) {
    return <Loading message="جاري تحميل المنبّه..." />;
  }

  return (
    <div className="p-4">
      <TaskAlertCompletion
        taskID={data.taskId}
        alertID={data.alertId}
        isCompleted={data.isCompleted}
        title={data.title}
        description={data.description}
        note={data.notice}
        scoreMeasurement={data.scoreMeasurement}
        measurementID={data.measurementID}
      />
    </div>
  );
}

using System;

namespace EventStore.Projections.Core.Services.Processing {
	public interface IResultWriter {
		//NOTE: subscriptionId should not be here.  Reconsider how to pass it to follower projection result writer
		void WriteEofResult(
			Guid subscriptionId, string partition, string resultBody, CheckpointTag causedBy, Guid causedByGuid,
			string correlationId);

		void WriteRunningResult(EventProcessedResult result);

		void AccountPartition(EventProcessedResult result);

		void EventsEmitted(EmittedEventEnvelope[] scheduledWrites, Guid causedBy, string correlationId);

		void WriteProgress(Guid subscriptionId, float progress);
	}
}

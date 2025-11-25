namespace takeup.Core.Ultilities.Datatype
{
	/// <summary>
	/// Tăng dần thời gian chờ khi không có request.
	/// 1 3 5 7 ...
	/// Khi có request mới, quay về 1.
	/// </summary>
	public class TimeBackoff
	{
		private int _requestCount;
		private int _waitCount;
		private int _stepSize = 1;

		public int RequestCount => _requestCount;
		public int Step => _stepSize;
		public int Wait => _waitCount;

		public void IncrementRequest()
		{
			_requestCount++;
		}

		public bool ShouldExecute()
		{
			// Khi có request mới
			if (_requestCount > 0)
			{
				_requestCount = 0;
				_stepSize = 1;
				_waitCount = 0;
				return true;
			}

			// Kiểm tra interval
			_waitCount++;

			if (_waitCount >= _stepSize)
			{
				_stepSize = _stepSize < (int.MaxValue - 2) ? (_stepSize + 2) : int.MaxValue;
				_waitCount = 0;
				return true;
			}

			return false;
		}

		public void Reset()
		{
			_requestCount = 0;
			_stepSize = 1;
			_waitCount = 0;
		}
	}
}
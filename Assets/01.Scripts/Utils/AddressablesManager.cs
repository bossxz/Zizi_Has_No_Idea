using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

/// <summary>
/// ��巹���� ���ҽ� ������ ����ϴ� ��ƿ ��ũ��Ʈ
/// </summary>
public class AddressablesManager : MonoSingleton<AddressablesManager>
{
	/// <summary>
	/// ���ҽ��� �������� �Լ�
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="name"></param>
	/// <returns></returns>
	public T GetResource<T>(string name)
	{
		var handle = Addressables.LoadAssetAsync<T>(name);
		
		handle.WaitForCompletion();
		
		return handle.Result;
	}

}

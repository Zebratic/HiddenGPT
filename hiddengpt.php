<?php
header('Content-Type: application/json');
$requesturl = $_SERVER['HTTP_REQUEST_URL'];
$apikey = "";
$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $requesturl);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
curl_setopt($ch, CURLOPT_POST, true);

// copy headers
$header = array();
foreach (getallheaders() as $key => $value) {
	// filter out unwanted headers
	if ($key == 'Host' || $key == 'Content-Length' || $key == 'Connection' || $key == 'Accept-Encoding') {
		continue;
	}

	$header[] = $key . ': ' . $value;
	// if Authorization header then extract apikey
	if ($key == 'Authorization') {
		$apikey = $value;
	}
}
curl_setopt($ch, CURLOPT_HTTPHEADER, $header);

// copy body
$body = file_get_contents('php://input');
curl_setopt($ch, CURLOPT_POSTFIELDS, $body);

$response = curl_exec($ch);
echo $response;
?>
